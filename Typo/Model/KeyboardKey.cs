using System.Windows.Controls;
using System.Windows.Input;

namespace Typo.Model
{
    public class KeyboardKey
    {
        public KeyboardKey(Key[] keys, Button[] buttons)
        {
            Keys = keys;
            Buttons = buttons;
        }

        public Key[] Keys { get; set; }
        public Button[] Buttons { get; set; }
    }
}