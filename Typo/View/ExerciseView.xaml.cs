using System.Windows.Controls;
using System.Windows.Input;
using Typo.Controller;
using Typo.Model;

namespace Typo.View
{
    /// <summary>
    ///     Interaction logic for ExerciseView.xaml
    /// </summary>
    public partial class ExerciseView : UserControl
    {
        public readonly MainWindow mainWindow;

        public ExerciseView(MainWindow mainWindow, ExerciseType exerciseType)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            ExerciseController = new ExerciseController(this, exerciseType);
        }

        public ExerciseView(MainWindow mainWindow, Exercise exercise)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            ExerciseController = new ExerciseController(this, exercise);
        }

        public ExerciseController ExerciseController { get; set; }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            ExerciseController.Handle_Key(sender, e);
        }

        private void UserControl_KeyUp(object sender, KeyEventArgs e)
        {
            ExerciseController.Handle_Key_Up(sender, e);
            ExerciseController.upperCaseLetter = false;
        }
    }
}