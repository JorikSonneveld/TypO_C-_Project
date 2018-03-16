using System.Windows;
using System.Windows.Controls;
using Typo.Controller;

namespace Typo.View
{
    /// <summary>
    ///     Interaction logic for StudentAccount.xaml
    /// </summary>
    public partial class StudentAccount : UserControl
    {
        private readonly DatabaseController databaseController;

        //these attributes are used to edit an existing student account
        private readonly bool Edit;

        //the mainWindow for navigating back to the student overview page
        private readonly MainWindow mainWindow;

        private readonly int StudentID;

        //this constructor is used when the button for creating a student account is clicked
        //as a result, this constructor passes the right information to the next constructor
        public StudentAccount(MainWindow mainWindow) : this(mainWindow, false, 0)
        {
        }

        //this constructor is used when the button for editing a student account is clicked
        public StudentAccount(MainWindow mainWindow, bool Edit, int StudentID)
        {
            InitializeComponent();
            databaseController = new DatabaseController();
            this.mainWindow = mainWindow;
            this.Edit = Edit;
            this.StudentID = StudentID;
            if (Edit)
                FillTextBoxes();
        }

        //method for filling the textboxes with the existing data from a certain student account
        //this will only happen when the button for editing student accounts is clicked
        private void FillTextBoxes()
        {
            var student = databaseController.GetStudentByID(StudentID);
            Name.Text = student.Name;
            Surname.Text = student.Surname;
        }

        //method for handling the event click for the save button
        //here the proper database funcion is called to store the data in the database.
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //this block of code will run if all mandatory fields are filled in
            if (Name.Text != string.Empty && Surname.Text != string.Empty)
            {
                //this block of code will run if the button for adding a new student account is clicked
                if (Edit == false && Password.Text != string.Empty)
                    databaseController.CreateStudent(Name.Text, Surname.Text, Password.Text, "Student", 2);
                //this block of code will run if the button for editing a student account is clicked and the password field is filled in
                else if (Password.Text != string.Empty)
                    databaseController.EditStudent(Name.Text, Surname.Text, Password.Text, StudentID);
                //this block of code will run if the button for editing a student account is clicked and the password field is not filled in
                else
                    databaseController.EditStudent(Name.Text, Surname.Text, StudentID);
                MessageBox.Show("Student account succesvol opgeslagen!");
                mainWindow.NewView(new StudentOverview(mainWindow));
            }
            //this block of code will run if not all mandatory fields are filled in
            else
            {
                MessageBox.Show("Niet alle veplichte velden zijn ingevuld!");
            }
        }

        //method for handling the event click for the return button
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NewView(new StudentOverview(mainWindow));
        }
    }
}