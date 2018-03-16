using System.Windows;
using System.Windows.Controls;
using Typo.Controller;

namespace Typo.View
{
    /// <summary>
    ///     Interaction logic for StudentOverview.xaml
    /// </summary>
    public partial class StudentOverview : UserControl
    {
        private readonly DatabaseController databaseController;

        //declaration of the mainWindow for navigation
        private readonly MainWindow mainWindow;

        //declaration of several contollers needed for creating new student accounts an showing all accounts in the wrappanel
        private readonly OverviewController overviewController;

        //contstructor for initialising the controllers
        public StudentOverview(MainWindow mainWindow)
        {
            InitializeComponent();
            overviewController = new OverviewController();
            this.mainWindow = mainWindow;
            //request the overview controller to fill the wrappanel with student information blocks
            overviewController.FillStudentGrid(mainWindow, StudentPanel);
        }

        //method to return to the teacher menu
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NewView(new TeacherMenu(mainWindow));
        }

        //method for creating a new student account
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NewView(new StudentAccount(mainWindow));
        }
    }
}