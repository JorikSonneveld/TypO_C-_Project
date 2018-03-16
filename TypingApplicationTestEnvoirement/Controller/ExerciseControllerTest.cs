using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TypingApplicationTestEnvironment.Controller
{
    [TestClass]
    public class ExerciseControllerTest
    {
        //[TestMethod]
        //public void CaluculateAccuracy_AccuracyShouldUpdate_WhenCalculateAccuracyIsCalled()
        //{
        //    //Arrange
        //    RichTextBox RichTextbox = new RichTextBox();
        //    ExerciseController exerciseController = new ExerciseController(RichTextbox);
        //    KeyData.GoodKeyPresses = 612;
        //    KeyData.KeystrokeCounter = 1094;

        //    //Act
        //    exerciseController.CaluculateAccuracy();

        //    //Assert
        //    Assert.AreEqual(56, KeyData.Accuracy);
        //}

        //[TestMethod]
        //public void CaluculateAccuracy_AccuracyShouldNotUpdate_WhenCalculateAccuracyIsCalledAndKeystrokecounterIsZero()
        //{
        //    //Arrange
        //    RichTextBox RichTextbox = new RichTextBox();
        //    ExerciseController exerciseController = new ExerciseController(RichTextbox);
        //    KeyData.Accuracy = 50;
        //    KeyData.KeystrokeCounter = 0;

        //    //Act
        //    exerciseController.CaluculateAccuracy();

        //    //Assert
        //    Assert.AreEqual(50, KeyData.Accuracy);
        //}

        //[TestMethod]
        //public void CaluculateAccuracy_AccuracyShouldNotUpdate_WhenCalculateAccuracyIsCalledAndGoodKeyPressesIsGreaterThanKeystrokeCounter()
        //{
        //    //Arrange
        //    RichTextBox RichTextbox = new RichTextBox();
        //    ExerciseController exerciseController = new ExerciseController(RichTextbox);
        //    KeyData.Accuracy = 50;
        //    KeyData.GoodKeyPresses = 1094;
        //    KeyData.KeystrokeCounter = 612;

        //    //Act
        //    exerciseController.CaluculateAccuracy();

        //    //Assert
        //    Assert.AreEqual(50, KeyData.Accuracy);
        //}

        //[TestMethod]
        //public void MakeWordsFromChars_ShouldReturnAnEmptyString_WhenListIsEmpty()
        //{
        //    //Arrange
        //    ExerciseController exerciseController = new ExerciseController();
        //    var charlist = new List<char>();

        //    //Act
        //    var result = exerciseController.MakeWordsFromChars(charlist, 4);

        //    //Assert
        //    Assert.AreEqual("", result);
        //}

        //[TestMethod]
        //public void MakeWordsFromChars_ShouldReturnAnEmptyString_WhenMaxLengthIsLowerThenTree()
        //{
        //    //Arrange
        //    ExerciseController exerciseController = new ExerciseController();
        //    var charlist = new List<char>();
        //    charlist.Add('k');
        //    charlist.Add('u');
        //    charlist.Add('r');

        //    //Act
        //    var result = exerciseController.MakeWordsFromChars(charlist, -1);

        //    //Assert
        //    Assert.AreEqual("", result);
        //}
    }
}