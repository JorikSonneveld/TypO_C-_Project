using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Typo;
using Typo.Controller;
using Typo.Model;
using Typo.View;

namespace TypingApplicationTestEnvironment.Controller
{
    /// <summary>
    ///     Summary description for KeyboardControllerTest
    /// </summary>
    [TestClass]
    public class KeyboardControllerTest
    {
        [TestMethod]
        public void HighlightCorrectButton_ShouldHighlightGivenButtonInGivenColor_WhenGivenButtonAndColor()
        {
            //Arrange
            var exerciseView = new ExerciseView(new MainWindow(), new NumberExercise(3, 4, 5));
            Brush brush;
            //Act
            exerciseView.ExerciseController.KeyboardController.HighlightCorrectButton('e', Brushes.Yellow);
            Button[] bs = exerciseView.ExerciseController.KeyboardController.FindButtons(Key.E);
            brush = bs[0].Background;
            //Assert
            Assert.AreEqual(Brushes.Yellow, brush);
        }

        [TestMethod]
        public void FindButtons_ShouldFindButtons_WhenExerciseViewIsInitializedAndWhenGivenKey()
        {
            //Arrange
            var exerciseView = new ExerciseView(new MainWindow(), new NumberExercise(3, 4, 5));
            //Act
            Button[] bs = exerciseView.ExerciseController.KeyboardController.FindButtons(Key.E);
            //Assert
            Assert.IsNotNull(bs);
        }

        [TestMethod]
        public void HighlightButtons_ShouldHighlightButtons_WhenGivenButtonsAndBrush()
        {
            //Arrange
            var exerciseView = new ExerciseView(new MainWindow(), new NumberExercise(3, 4, 5));
            var b1 = new Button();
            var b2 = new Button();
            Button[] buttons = {b1, b2};
            //Act
            exerciseView.ExerciseController.KeyboardController.HighightButtons(buttons, Brushes.Red);
            //Assert
            Assert.AreEqual(Brushes.Red, b1.Background);
            Assert.AreEqual(Brushes.Red, b2.Background);
        }

        [TestMethod]
        public void NumPadEnabled_ShouldSetNumPad_WhenGivenBool()
        {
            //Arrange
            var exerciseView = new ExerciseView(new MainWindow(), new NumberExercise(3, 4, 5));
            //Act
            exerciseView.ExerciseController.KeyboardController.NumPadEnabled(false);
            //Assert
            Assert.IsFalse(exerciseView.keyBoard.IsVisible);
        }

        [TestMethod]
        public void ResolveKey_ShouldReturnKey_WhenGivenChar()
        {
            //Act
            var k = KeyboardController.ResolveKey('e');
            //Assert
            Assert.AreEqual(Key.E, k);
        }
    }
}