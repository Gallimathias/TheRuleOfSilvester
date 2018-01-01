﻿using System;
using System.Collections.Generic;
using System.Text;
using TheRuleOfSilvester.Core;

namespace TheRuleOfSilvester
{
    public class InputComponent : IInputCompoment
    {
        public bool Up => LastKey == (int)ConsoleKey.W || LastKey == (int)ConsoleKey.UpArrow;
        public bool Down => LastKey == (int)ConsoleKey.S || LastKey == (int)ConsoleKey.DownArrow;
        public bool Left => LastKey == (int)ConsoleKey.A || LastKey == (int)ConsoleKey.LeftArrow;
        public bool Right => LastKey == (int)ConsoleKey.D || LastKey == (int)ConsoleKey.RightArrow;

        public int LastKey { get;  set; }

        public InputComponent()
        {
            LastKey = -1;
        }

        internal void Listen()
        {
            while (true)
            {
                LastKey = (int)Console.ReadKey().Key;
            }
        }

    }
}