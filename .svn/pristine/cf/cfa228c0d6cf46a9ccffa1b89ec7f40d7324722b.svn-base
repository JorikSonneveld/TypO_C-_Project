using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Typo.Controller;
using Typo.Model.Database;

namespace Typo.View
{
    /// <summary>
    ///     Interaction logic for MenuStudentStatistics.xaml
    /// </summary>
    public partial class MenuStudentStatistics : UserControl
    {
        private readonly DatabaseController databaseController = new DatabaseController();
        private readonly MainWindow mainWindow;
        private readonly Student student;

        public MenuStudentStatistics(MainWindow mainWindow, int ID)
        {
            this.mainWindow = mainWindow;
            student = databaseController.GetStudentByID(ID);
            InitializeComponent();
            DataContext = databaseController.CreateResultBindings(student);
            DataGridResults.ItemsSource = databaseController.GetResultsPerStudent(ID).ToList();
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NewView(new MainMenu(mainWindow));
        }
    }
}