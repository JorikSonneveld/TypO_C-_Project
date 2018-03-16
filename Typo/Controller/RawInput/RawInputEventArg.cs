﻿using System;

namespace Typo.Controller.RawInput
{
    public class RawInputEventArg : EventArgs
    {
        public RawInputEventArg(KeyPressEvent arg)
        {
            KeyPressEvent = arg;
        }

        public KeyPressEvent KeyPressEvent { get; }
    }
}