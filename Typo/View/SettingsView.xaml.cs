using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Typo.Properties;
using Xceed.Wpf.Toolkit;

namespace Typo.View
{
    /// <summary>
    ///     Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        private readonly MainWindow mainWindow;

        public SettingsView(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            SetColors();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NewView(new MainMenu(mainWindow));
        }

        private void ChangeColor(object sender, RoutedEventArgs e)
        {
            var picker = sender as ColorPicker;

            var newColor = ReturnIntFromColor((Color) picker.SelectedColor);
            switch (picker.Name)
            {
                case "TextColor":
                    Settings.Default.TextColor = newColor;
                    break;
                case "CorrectColor":
                    Settings.Default.CorrectColor = newColor;
                    break;
                case "FalseColor":
                    Settings.Default.FalseColor = newColor;
                    break;
            }
            Settings.Default.Save();
        }

        private void SetColors()
        {
            //Properties.Settings.Default.
            TextColor.Background = ReturnBrushColorFromInt(Settings.Default.TextColor);
            CorrectColor.Background = ReturnBrushColorFromInt(Settings.Default.CorrectColor);
            FalseColor.Background = ReturnBrushColorFromInt(Settings.Default.FalseColor);
            NumPadCheck.IsChecked = Settings.Default.NUM;
        }

        public static SolidColorBrush ReturnBrushColorFromInt(int inputInt)
        {
            //Properties.Settings.Default.
            var bytes = BitConverter.GetBytes(inputInt);
            return new SolidColorBrush(Color.FromArgb(bytes[3], bytes[2], bytes[1], bytes[0]));
        }

        public static int ReturnIntFromColor(Color color)
        {
            return BitConverter.ToInt32(new[] {color.B, color.G, color.R, color.A}, 0);
        }

        private void NumPadCheck_Click(object sender, RoutedEventArgs e)
        {
            bool check = NumPadCheck.IsChecked ?? false;
            Settings.Default.NUM = check;
            Settings.Default.Save();
        }
    }
}