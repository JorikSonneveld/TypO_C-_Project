﻿using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using Typo.Model;

namespace Typo.View
{
    /// <summary>
    ///     Interaction logic for Keyboard.xaml
    /// </summary>
    public partial class Keyboard : UserControl
    {
        public Keyboard()
        {
            InitializeComponent();
        }

        //make a list where key values are linked to a button on the keyboard
        public List<KeyboardKey> MakeKeyList()
        {
            return new List<KeyboardKey>
            {
                new KeyboardKey(new[] {Key.Q}, new[] {btnQ}),
                new KeyboardKey(new[] {Key.W}, new[] {btnW}),
                new KeyboardKey(new[] {Key.E}, new[] {btnE}),
                new KeyboardKey(new[] {Key.R}, new[] {btnR}),
                new KeyboardKey(new[] {Key.T}, new[] {btnT}),
                new KeyboardKey(new[] {Key.Y}, new[] {btnY}),
                new KeyboardKey(new[] {Key.U}, new[] {btnU}),
                new KeyboardKey(new[] {Key.I}, new[] {btnI}),
                new KeyboardKey(new[] {Key.O}, new[] {btnO}),
                new KeyboardKey(new[] {Key.P}, new[] {btnP}),
                new KeyboardKey(new[] {Key.A}, new[] {btnA}),
                new KeyboardKey(new[] {Key.S}, new[] {btnS}),
                new KeyboardKey(new[] {Key.D}, new[] {btnD}),
                new KeyboardKey(new[] {Key.F}, new[] {btnF}),
                new KeyboardKey(new[] {Key.G}, new[] {btnG}),
                new KeyboardKey(new[] {Key.H}, new[] {btnH}),
                new KeyboardKey(new[] {Key.J}, new[] {btnJ}),
                new KeyboardKey(new[] {Key.K}, new[] {btnK}),
                new KeyboardKey(new[] {Key.L}, new[] {btnL}),
                new KeyboardKey(new[] {Key.Z}, new[] {btnZ}),
                new KeyboardKey(new[] {Key.X}, new[] {btnX}),
                new KeyboardKey(new[] {Key.C}, new[] {btnC}),
                new KeyboardKey(new[] {Key.V}, new[] {btnV}),
                new KeyboardKey(new[] {Key.B}, new[] {btnB}),
                new KeyboardKey(new[] {Key.N}, new[] {btnN}),
                new KeyboardKey(new[] {Key.M}, new[] {btnM}),
                new KeyboardKey(new[] {Key.D1, Key.NumPad1}, new[] {btn1, btn1N}),
                new KeyboardKey(new[] {Key.D2, Key.NumPad2}, new[] {btn2, btn2N}),
                new KeyboardKey(new[] {Key.D3, Key.NumPad3}, new[] {btn3, btn3N}),
                new KeyboardKey(new[] {Key.D4, Key.NumPad4}, new[] {btn4, btn4N}),
                new KeyboardKey(new[] {Key.D5, Key.NumPad5}, new[] {btn5, btn5n}),
                new KeyboardKey(new[] {Key.D6, Key.NumPad6}, new[] {btn6, btn6N}),
                new KeyboardKey(new[] {Key.D7, Key.NumPad7}, new[] {btn7, btn7N}),
                new KeyboardKey(new[] {Key.D8, Key.NumPad8}, new[] {btn8, btn8N}),
                new KeyboardKey(new[] {Key.D9, Key.NumPad9}, new[] {btn9, btn9N}),
                new KeyboardKey(new[] {Key.D0, Key.NumPad0}, new[] {btn0, btn0N}),
                new KeyboardKey(new[] {Key.Space}, new[] {btnSpace})
            };
        }
    }
}