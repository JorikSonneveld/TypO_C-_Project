﻿using System.Collections.Generic;
using System.Windows.Input;

namespace Typo.Model
{
    public class KeyData
    {
        public static int GoodKeyPresses = 0;
        public static int KeystrokeTime = 0;
        public static int KeystrokesPerMinute = 0;
        public static int Accuracy = 100;
        public static int KeystrokeCounter = 0;

        public static List<StringKey> keysList = new List<StringKey>
        {
            new StringKey(Key.OemComma, ",<"),
            new StringKey(Key.OemPeriod, ".>"),
            new StringKey(Key.OemQuestion, "/?"),
            new StringKey(Key.OemOpenBrackets, "[{"),
            new StringKey(Key.OemCloseBrackets, "]}"),
            new StringKey(Key.Oem5, "|'\'"),
            new StringKey(Key.OemPlus, "=+"),
            new StringKey(Key.D1, "1!"),
            new StringKey(Key.D2, "2@"),
            new StringKey(Key.D3, "3#"),
            new StringKey(Key.D4, "4$"),
            new StringKey(Key.D5, "5%"),
            new StringKey(Key.D6, "6^"),
            new StringKey(Key.D7, "7&"),
            new StringKey(Key.D8, "8*"),
            new StringKey(Key.D9, "9("),
            new StringKey(Key.D0, "0)"),
            new StringKey(Key.OemMinus, "-_"),
            new StringKey(Key.OemPlus, "=+")
        };

        public long CurrentMillisec;
        public long Delay;
        public long StartMillisec;
        public int WrongKeyPresses = 0;
    }

    public class StringKey
    {
        public StringKey(Key key, string String)
        {
            this.key = key;
            this.String = String;
        }

        public Key key { get; set; }
        public string String { get; set; }
    }
}