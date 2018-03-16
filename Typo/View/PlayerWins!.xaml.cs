using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Typo.View
{
    /// <summary>
    ///     Interaction logic for PlayerWins_.xaml
    /// </summary>
    public partial class PlayerWins_ : UserControl
    {
        public PlayerWins_(int player)
        {
            InitializeComponent();
            if (player == 1)
            {
                Label.Content = "Player 1 Wins!";
                //BitmapImage logo = new BitmapImage();
                //logo.BeginInit();
                //logo.UriSource = new Uri("pack://siteoforigin:,,,/Resources/iu.png");
                //logo.EndInit();
                //Image.Source = logo;
            }
            else
            {
                Label.Content = "Player 2 Wins!";
                var logo = new BitmapImage();
                //logo.BeginInit();
                //logo.UriSource = new Uri("pack://siteoforigin:,,,/Resources/iu2.png");
                //logo.EndInit();
                //Image.Source = logo;
            }
        }
    }
}