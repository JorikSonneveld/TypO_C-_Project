using System.Windows.Controls;

namespace Typo.View
{
    /// <summary>
    ///     Interaction logic for PlayerView.xaml
    /// </summary>
    public partial class PlayerView : UserControl
    {
        public PlayerView()
        {
            InitializeComponent();
        }

        public void SwapSlider()
        {
            var temp = ScoreColumn.Width;
            ScoreColumn.Width = TextColumn.Width;
            TextColumn.Width = temp;
            Score.SetValue(Grid.ColumnProperty, 0);
            ExerciseTextBox.SetValue(Grid.ColumnProperty, 1);
        }
    }
}