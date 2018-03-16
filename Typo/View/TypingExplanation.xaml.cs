using System.Windows.Controls;

namespace Typo.View
{
    /// <summary>
    ///     Interaction logic for TypingExplanation.xaml
    /// </summary>
    public partial class TypingExplanation : UserControl
    {
        private MainWindow mainWindow;

        public TypingExplanation(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }
    }
}