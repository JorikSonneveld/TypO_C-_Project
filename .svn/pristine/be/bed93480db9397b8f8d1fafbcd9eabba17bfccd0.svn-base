using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Typo.Controller;
using Typo.View;

namespace Typo
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Frame MainFrame;
        public UserControl usercontrol;

        public MainWindow()
        {
            //DatabaseFill
            var database = new DatabaseController();
            if (!database.ApplicationDatabase.Teachers.Any())
                database.FillDatabase();

            InitializeComponent();
        }

        public void ClearMainFrameContent()
        {
            if (!MainFrame.CanGoBack && !MainFrame.CanGoForward)
                return;

            var entry = MainFrame.RemoveBackEntry();
            while (entry != null)
                entry = MainFrame.RemoveBackEntry();

            MainFrame.Navigate(new PageFunction<string> {RemoveFromJournal = true});
        }

        public void NewView(UserControl usercontrol)
        {
            ClearMainFrameContent();
            this.usercontrol = usercontrol;
            MainFrame.Content = usercontrol;
            usercontrol.Focus();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            var Usertype = Application.Current.Properties["UserType"];
            if (Usertype != null)
                if (Application.Current.Properties["UserType"].ToString() == "Teacher")
                    NewView(new TeacherMenu(this));
                else if (Application.Current.Properties["UserType"].ToString() == "Student")
                    NewView(new MainMenu(this));
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void MainFrame_Loaded(object sender, RoutedEventArgs e)
        {
            MainFrame = sender as Frame;
            NewView(new Login());
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}