using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using Typo.Controller;
using Typo.Controller.RawInput;

namespace Typo.View
{
    /// <summary>
    ///     Interaction logic for Multiplayer.xaml
    /// </summary>
    public partial class Multiplayer : UserControl
    {
        private readonly IntPtr keyHandle;
        private readonly RawInput rawInput;
        private bool externKeyboard;
        public MainWindow mainWindow;
        public MultiplayerController MultiplayerController;

        public Multiplayer(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            MessageBox.Show("Plug in secondary keyboard!");
            MessageBox.Show("Get Ready!");
            MultiplayerController = new MultiplayerController(this);
            keyHandle = new WindowInteropHelper(this.mainWindow).Handle; //KeyEvent handler
            rawInput = new RawInput(keyHandle, true); //RawInput reader
            rawInput.KeyPressed += OnKeyPressed; //Void OnKeyPress when KeyPress
            Focus();
        }

        //Detect if keypress is from external keyboard
        private void OnKeyPressed(object sender, RawInputEventArg e)
        {
            externKeyboard = e.KeyPressEvent.Name.Equals("HID Keyboard Device");
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (externKeyboard)
                MultiplayerController.Player2_Handle_Key_Down(sender, e);
            else
                MultiplayerController.Player1_Handle_Key_Down(sender, e);
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (externKeyboard)
                MultiplayerController.upperCaseLetterPlayer2 = false;
            else
                MultiplayerController.upperCaseLetterPlayer1 = false;
        }
    }
}