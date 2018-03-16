using System;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Typo.Model;
using Typo.View;

namespace Typo.Controller
{
    public class MultiplayerController
    {
        public DatabaseController databaseController = new DatabaseController();
        public Multiplayer Multiplayer;
        public bool upperCaseLetterPlayer1;
        public bool upperCaseLetterPlayer2;
        public WordExercise WordExercisePlayer1, WordExercisePlayer2;


        public MultiplayerController(Multiplayer multiplayer)
        {
            var wordExercise = new WordExercise(databaseController.RetrieveRandomDbWords());
            WordExercisePlayer1 = wordExercise;
            WordExercisePlayer2 = wordExercise;
            Multiplayer = multiplayer;
            Multiplayer.Player1.ExerciseTextBoxPlayer.Inlines.Add(new Run(WordExercisePlayer1.ExerciseString));
            Multiplayer.Player2.ExerciseTextBoxPlayer.Inlines.Add(new Run(WordExercisePlayer2.ExerciseString));
            Multiplayer.Player1.ScoreSlider.Maximum = WordExercisePlayer1.ExerciseString.Length;
            Multiplayer.Player2.ScoreSlider.Maximum = WordExercisePlayer2.ExerciseString.Length;
            Multiplayer.Player2.SwapSlider();
        }

        public void Player1_Handle_Key_Down(object sender, KeyEventArgs e)
        {
            var inputKey = KeyEventConverter(e, ref upperCaseLetterPlayer1);
            if (inputKey == WordExercisePlayer1.ExerciseString[0].ToString())
            {
                SetNextExpectedKey(Multiplayer.Player1.ExerciseTextBoxPlayer, WordExercisePlayer1, Brushes.Green);
                Multiplayer.Player1.ScoreSlider.Value = WordExercisePlayer1.InputString.Length;
            }
            if (WordExercisePlayer1.ExerciseString.Length == 0)
                Multiplayer.mainWindow.MainFrame.Content = new PlayerWins_(1);
        }

        public void Player2_Handle_Key_Down(object sender, KeyEventArgs e)
        {
            var inputKey = KeyEventConverter(e, ref upperCaseLetterPlayer2);
            if (inputKey == WordExercisePlayer2.ExerciseString[0].ToString())
            {
                SetNextExpectedKey(Multiplayer.Player2.ExerciseTextBoxPlayer, WordExercisePlayer2, Brushes.Red);
                Multiplayer.Player2.ScoreSlider.Value = WordExercisePlayer2.InputString.Length;
            }
            if (WordExercisePlayer2.ExerciseString.Length == 0)
                Multiplayer.mainWindow.MainFrame.Content = new PlayerWins_(2);
        }

        private string KeyEventConverter(KeyEventArgs e, ref bool uppercase)
        {
            var inputString = e.Key.ToString().ToLower();
            //Check if inputKey is not a letter
            if (inputString.Length > 1)
                if (inputString == "leftshift" || inputString == "rightshift")
                {
                    uppercase = true;
                    return null;
                }
                else if (inputString == "space" || inputString == "deadcharprocessed")
                {
                    inputString = " ";
                }
                else
                {
                    inputString = OemCodeConvert(e, uppercase);
                }

            if (Console.CapsLock)
                uppercase = true;

            if (uppercase)
                inputString = inputString.ToUpper();
            return inputString;
        }

        private string OemCodeConvert(KeyEventArgs e, bool upperCaseLetter)
        {
            string returnString;
            var stringKey = KeyData.keysList.FirstOrDefault(k => k.key == e.Key);
            if (stringKey != null)
                returnString = stringKey.String;
            else
                return "";

            if (upperCaseLetter)
                returnString = returnString[returnString.Length - 1] + "";
            else
                returnString = returnString[0] + "";
            return returnString;
        }

        public void SetNextExpectedKey(Paragraph paragraph, WordExercise wordExercise, Brush brush)
        {
            wordExercise.InputString += wordExercise.ExerciseString[0];
            wordExercise.ExerciseString =
                wordExercise.ExerciseString.Substring(1, wordExercise.ExerciseString.Count() - 1);
            paragraph.Inlines.Clear();
            paragraph.Inlines.Add(new Run(wordExercise.InputString) {Foreground = brush});
            paragraph.Inlines.Add(new Run(wordExercise.ExerciseString));
        }
    }
}