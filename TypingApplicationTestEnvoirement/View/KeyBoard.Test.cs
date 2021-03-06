﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TypingApplicationTestEnvironment
{
    [TestClass]
    public class UnitTest1
    {
        //[TestMethod]
        //public void Keyboard_ShouldAddKeys_WhenKeyboardIsInitialized()
        //{
        //    //Arrange
        //    KeyBoard keyBoard = new KeyBoard();

        //    //Act

        //    //Assert
        //    Assert.IsNotNull(keyBoard.Keys);
        //}

        //[TestMethod]
        //public void SetKeyColor_ShouldChangeKeyColor_WhenFunctionIsCalled()
        //{
        //    //Arrange
        //    KeyBoard keyBoard = new KeyBoard();
        //    Button button1 = new Button {BackColor = Color.White};
        //    Color color1 = Color.Blue;;
        //    //Act
        //    keyBoard.SetKeyColor(button1, color1);
        //    //Assert
        //    Assert.IsTrue(button1.BackColor == Color.Blue);
        //}

        //[TestMethod]
        //public void ConvertKeyCodeToChar_ShouldReturChar_WhenGivenAnInt()
        //{
        //    //Arrange
        //    KeyBoard keyBoard = new KeyBoard();
        //    int integer = 71;
        //    //Act
        //    char result = keyBoard.ConvertKeyCodeToChar(integer);
        //    //Assert
        //    Assert.AreEqual(result, 'G');
        //}

        //[TestMethod]
        //public void CovertCharToKeyCode_ShouldReturnInt_WhenGivenAChar()
        //{
        //    //Arrange
        //    KeyBoard keyBoard = new KeyBoard();
        //    char character = 'G';
        //    //Act
        //    int result = keyBoard.ConvertCharacterToKeyCode(character);
        //    //Assert
        //    Assert.AreEqual(result, 71);
        //}

        //[TestMethod]
        //public void ConvertKeyCodeToButton_ShouldReturnCorrectButton_WhenGivenAnInt()
        //{
        //    //Arrange
        //    KeyBoard keyBoard = new KeyBoard();
        //    //Act
        //    Button button1 = keyBoard.ConvertKeyCodeToButton(71);
        //    //Assert
        //    Assert.AreEqual(button1, keyBoard.btnG);
        //}

        //[TestMethod]
        //public void ResetKeyColor_SloudSetKeyToWhite_WhenFunctionIsCalled()
        //{
        //    //Arrange
        //    KeyBoard keyBoard = new KeyBoard();
        //    keyBoard.btnG.BackColor = Color.Blue;
        //    //Act
        //    keyBoard.ResetKeyColor(71);
        //    //Assert
        //    Assert.IsTrue(keyBoard.btnG.BackColor == Color.White);
        //}

        //[TestMethod]
        //public void ActKey_ShouldChangeKeyColorToGrey_WhenExpectedKeyAndPressedKeyAreSame()
        //{
        //    //Arrange
        //    KeyBoard keyBoard = new KeyBoard();
        //    int Expected = Color.Gray.ToArgb();
        //    //Act
        //    keyBoard.ActKey(71, 'G');
        //    Color color = keyBoard.btnG.BackColor;
        //    int Actual = color.ToArgb();
        //    //Assert
        //    Assert.AreEqual(Expected, Actual);
        //}

        //[TestMethod]
        //public void ActKey_ShouldChangePressedKeyColorToSetColor_WhenExpectedKeyAndPressedKeyAreNotSame()
        //{
        //    //Arrange
        //    KeyBoard keyBoard = new KeyBoard();
        //    Color actual = Color.FromArgb(keyBoard.WrongKeyColor);
        //    //Act
        //    keyBoard.ActKey(72, 'G');
        //    //Assert
        //    Assert.AreEqual(keyBoard.btnH.BackColor, actual);
        //}

        //[TestMethod]
        //public void ActKey_ShouldChangeCorrectKeyColorToSetColor_WhenExpectedKeyAndPressedKeyAreNotSame()
        //{
        //    //Arrange
        //    KeyBoard keyBoard = new KeyBoard();
        //    Color actual = Color.FromArgb(keyBoard.CorrectKeyColor);
        //    //Act
        //    keyBoard.ActKey(72, 'G');
        //    //Assert
        //    Assert.AreEqual(keyBoard.btnG.BackColor, actual);
        //}

        //[TestMethod]
        //public void HighlightNextKey_ShouldHighlightNextKey_WhenGivenNextChar()
        //{
        //    //Arrange
        //    KeyBoard keyBoard = new KeyBoard();
        //    //Act
        //    keyBoard.HighLightKey('g');
        //    //Assert
        //    Assert.AreEqual(keyBoard.btnG.BackColor, Color.Gold);
        //}
    }
}