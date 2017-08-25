using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Professional_calculator.Model
{
    static class InputFilter
    {
        static Key previousKey = new Key();

        static Key[] allowedKeys = new Key[]
        {
            Key.D0,
            Key.D1,
            Key.D2,
            Key.D3,
            Key.D4,
            Key.D5,
            Key.D6,
            Key.D7,
            Key.D8,
            Key.D9,

            //Key.OemMinus,
            //Key.OemPlus,

            Key.Back,
            Key.Delete,

            Key.Subtract,
            Key.Add,
            Key.Multiply,
            Key.Divide,

            Key.NumPad0,
            Key.NumPad1,
            Key.NumPad2,
            Key.NumPad3,
            Key.NumPad4,
            Key.NumPad5,
            Key.NumPad6,
            Key.NumPad7,
            Key.NumPad8,
            Key.NumPad9,

            Key.Right,
            Key.Left,

            Key.Decimal
        };

        static public bool IsKeyAllowed(Key key)
        {
            if (IsThisAndPrevious_ArithmeticSymbols(key))
            {
                previousKey = key;
                return false;
            }

            foreach(var pushedKey in allowedKeys)
            {
                if(key == pushedKey)
                {
                    return true;
                }
            }
            return false;
        }

        static bool IsThisAndPrevious_ArithmeticSymbols(Key pushedKey)
        {
            
            if(IsArithmeticSymbol(pushedKey))
            {
                return IsArithmeticSymbol(previousKey) ? true : false;
            }
            return false;
        }

        static bool IsArithmeticSymbol(Key key)
        {
            if ((key == Key.Add) || (key == Key.Subtract) ||
                (key == Key.Multiply) || (key == Key.Divide))
            {
                return true;
            }
            else
                return false;
        }
    }
}
