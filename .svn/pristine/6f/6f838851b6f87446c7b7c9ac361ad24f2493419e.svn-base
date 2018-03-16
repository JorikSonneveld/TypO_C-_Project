using System.Windows;
using System.Windows.Controls;

namespace Typo.View
{
    /// <summary>
    ///     Interaction logic for TeacherMenu.xaml
    /// </summary>
    public partial class TeacherMenu : UserControl
    {
        //declaration of the mainWindow for navigation
        private readonly MainWindow mainWindow;

        //construction for initialising the mainWindow for navigation
        public TeacherMenu(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        //method for showing the Manage courses view as a result of clicking the Manage courses button
        private void Manage_Courses_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NewView(new CourseView(mainWindow));
        }

        //method for showing the student overview as a result of clicking the Student overview button
        private void Student_Overview_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NewView(new StudentOverview(mainWindow));
        }

        //method to shut the application down
        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}