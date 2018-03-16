using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using Typo.Controller;
using Typo.Model.Database;
using MessageBox = System.Windows.Forms.MessageBox;
using UserControl = System.Windows.Controls.UserControl;

namespace Typo.View
{
    /// <summary>
    ///     Interaction logic for StudentStatistics.xaml
    /// </summary>
    public partial class StudentStatistics : UserControl
    {
        private readonly DatabaseController databaseController = new DatabaseController();
        private readonly int lol = 2456;
        private readonly MainWindow mainWindow;
        private readonly Student student;

        public StudentStatistics(MainWindow mainWindow, int ID)
        {
            this.mainWindow = mainWindow;
            student = databaseController.GetStudentByID(ID);
            InitializeComponent();
            var Bindings = CreateBindings(student, lol);
            Results.ItemsSource = databaseController.GetResultsPerStudent(ID).ToList();
            DataContext = Bindings;
        }

        private List<object> CreateBindings(Student student, int test)
        {
            var Bindings = new List<object>();
            Bindings.Add(student);
            Bindings.Add(databaseController.GetAverageAccuracy(student.ID));
            Bindings.Add(databaseController.GetAverageKeysPerMinute(student.ID));
            Bindings.Add(databaseController.GetResultCount(student.ID, false));
            Bindings.Add(databaseController.GetResultCount(student.ID, true));
            return Bindings;
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.MainFrame.NavigationService.GoBack();
        }

        //method for editing an existing student account
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var Edit = true;
            mainWindow.NewView(new StudentAccount(mainWindow, Edit, student.ID));
            Edit = false;
        }

        //method for deleting an existing student account
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //show a messagebox to inform if the user is sure about deleting the account
            var result = MessageBox.Show("Are you sure you want to delete \"" + student.Name + "\"", "Delete",
                MessageBoxButtons.YesNo);
            //if the user is sure, delete the account
            if (result == DialogResult.Yes)
            {
                databaseController.DeleteStudent(student.ID);
                mainWindow.NewView(new StudentOverview(mainWindow));
            }
        }
    }
}