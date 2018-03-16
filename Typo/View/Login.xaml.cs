using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Typo.Controller;

namespace Typo.View
{
    /// <summary>
    ///     Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        private readonly LoginController loginController = new LoginController();

        public Login()
        {
            InitializeComponent();
            Username.Focus();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Username.Clear();
            Password.Clear();
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;

            if (e.Key == Key.Enter)

                base.OnPreviewKeyDown(e);
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (loginController.CheckCredentials(Username.Text, LoginController.Hash(Password.Password)))
            {
                var mainWindow = (MainWindow) Window.GetWindow(this);
                Console.WriteLine((string) Application.Current.Properties["UserType"]);
                if ((string) Application.Current.Properties["UserType"] == "Teacher")
                    mainWindow.NewView(new TeacherMenu(mainWindow));
                else
                    mainWindow.NewView(new MainMenu(mainWindow));
            }
            else
            {
                incorrect.Visibility = Visibility.Visible; //set label visible
            }
        }

        //Press OK button when enter pressed
        private void KeyDownEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Ok_Click(sender, e);
        }
    }
}