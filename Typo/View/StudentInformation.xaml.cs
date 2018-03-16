using System.Windows;
using System.Windows.Controls;
using Typo.Model.Database;

namespace Typo.View
{
    /// <summary>
    ///     Interaction logic for StudentInformation.xaml
    /// </summary>
    public partial class StudentInformation : UserControl
    {
        private readonly int ConnectStudentID;

        //attributes to for navigation
        private readonly MainWindow mainWindow;

        //constructor for initialising private attributes and 
        public StudentInformation(MainWindow mainWindow, Student student)
        {
            InitializeComponent();
            //initialising content of student information panel
            this.mainWindow = mainWindow;
            FirstName.Content = student.Name;
            Surname.Content = student.Surname;
            StudentID.Content = student.ID.ToString();
            ConnectStudentID = student.ID;
        }

        //method for showing the student statistics view
        private void BtnStudent_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NewView(new StudentStatistics(mainWindow, ConnectStudentID));
        }
    }
}