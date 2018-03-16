using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Typo.Model;
using Typo.Properties;
using Typo.View;

namespace Typo.Controller
{
    public class KeyboardController
    {

        public CharacterPicker characterPicker;
        public ExerciseView ExerciseView { get; set; }
        public List<KeyboardKey> keys;

        public KeyboardController(CharacterPicker characterPicker)
        {
            this.characterPicker = characterPicker;
            keys = characterPicker.keyBoard.MakeKeyList();
        }

        public KeyboardController(ExerciseView exerciseView, ExerciseController exerciseController)
        {
            ExerciseView = exerciseView;
            keys = exerciseView.keyBoard.MakeKeyList();
            NumPadEnabled(Settings.Default.NUM);
        }

        //act on key
        public void HandleKey_Down(KeyEventArgs e, Brush brush)
        {
            var bs = FindButtons(e.Key);
            if (bs == null)
                return;

            HighightButtons(bs, brush);
        }

        //reset key
        public void HandleKey_Up(KeyEventArgs e, Brush brush)
        {
            var bs = FindButtons(e.Key);
            if (bs == null)
                return;

            HighightButtons(bs, brush);
        }

        //highlight a key by character
        public void HighlightCorrectButton(char correctCharacter, Brush brush)
        {
            var k = ResolveKey(correctCharacter);
            var bs = FindButtons(k);
            if (bs == null)
                return;
            HighightButtons(bs, brush);
        }

        //highlight buttons
        public void HighightButtons(Button[] buttons, Brush brush)
        {
            foreach (var b in buttons)
                b.Background = brush;
        }


        //return all buttons linked to a key
        public Button[] FindButtons(Key key)
        {
            return keys.Where(x => x.Keys.Contains(key)).Select(x => x.Buttons).FirstOrDefault();
        }

        //disable/enable numpad
        public void NumPadEnabled(bool enabled)
        {
            ExerciseView.keyBoard.NUMpad.IsEnabled = enabled;
        }

        //convert char to key
        [DllImport("user32.dll")]
        private static extern short VkKeyScan(char ch);

        public static Key ResolveKey(char charToResolve)
        {
            return KeyInterop.KeyFromVirtualKey(VkKeyScan(charToResolve));
        }
    }
}