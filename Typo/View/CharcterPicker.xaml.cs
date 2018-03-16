﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Typo.Controller;
using Typo.Model;

namespace Typo.View
{
    /// <summary>
    ///     Interaction logic for CharcterPicker.xaml
    /// </summary>
    public partial class CharacterPicker : UserControl
    {
        private readonly List<char> characterList = new List<char>();
        private readonly KeyboardController keyboardController;
        private readonly MainWindow mainWindow;


        public CharacterPicker(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
            keyboardController = new KeyboardController(this);
        }

        public string Characters { get; set; }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.NewView(new MainMenu(mainWindow));
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if(characterList.Count == 0)
            {
                MessageBox.Show("Please select characters to practice with!");
                return;
            }
            mainWindow.NewView(new ExerciseView(mainWindow,
                new CharacterExercise(characterList, (int) MaxWordLengthSlider.Value)));
        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            var key = new KeyConverter().ConvertToString(e.Key)[0];
            if (!characterList.Contains(char.ToLower(key)))
            {
                characterList.Add(char.ToLower(key));
                keyboardController.HandleKey_Down(e, Brushes.Gold);
            }
            else
            {
                characterList.Remove(char.ToLower(key));
                keyboardController.HandleKey_Down(e, Brushes.LightGray);
            }


            MakeStringFormCharacterlist(characterList);
            CharactersString.Content = Characters;
            InvalidateVisual();
        }

        private void MakeStringFormCharacterlist(List<char> chars)
        {
            Characters = string.Empty;
            foreach (var c in chars)
                Characters += c + " ";
            Console.WriteLine(Characters);
        }
    }
}