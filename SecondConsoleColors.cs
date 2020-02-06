using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondConsoleAPI
{
    public enum SecondConsoleColors { 
        Black = 0,
        DarkBlue = 1,
        DarkGreen = 2,
        DarkCyan = 3,
        DarkRed = 4,
        DarkMagenta = 5,
        DarkYellow = 6,
        Gray = 7,
        DarkGray = 8,
        Blue = 9,
        Green = 10,
        Cyan = 11,
        Red = 12,
        Magenta = 13,
        Yellow = 14,
        White = 15
    }
    internal class ColorTools
    {
        public static Color GetColor(SecondConsoleColors colors, Color defaultcolor)
        {
            switch (colors)
            {
                case SecondConsoleColors.Black:
                    return Color.Black;
                case SecondConsoleColors.DarkBlue:
                    return Color.DarkBlue;
                case SecondConsoleColors.DarkGreen:
                    return Color.DarkGreen;
                case SecondConsoleColors.DarkCyan:
                    return Color.DarkCyan;
                case SecondConsoleColors.DarkRed:
                    return Color.DarkRed;
                case SecondConsoleColors.DarkMagenta:
                    return Color.DarkMagenta;
                case SecondConsoleColors.DarkYellow:
                    return Color.Yellow;
                case SecondConsoleColors.Gray:
                    return Color.Gray;
                case SecondConsoleColors.DarkGray:
                    return Color.DarkGray;
                case SecondConsoleColors.Blue:
                    return Color.Blue;
                case SecondConsoleColors.Green:
                    return Color.Green;
                case SecondConsoleColors.Cyan:
                    return Color.Cyan;
                case SecondConsoleColors.Red:
                    return Color.Red;
                case SecondConsoleColors.Magenta:
                    return Color.Magenta;
                case SecondConsoleColors.Yellow:
                    return Color.LightGoldenrodYellow;
                case SecondConsoleColors.White:
                    return Color.White;
            }
            return defaultcolor;
        }  
        public static Color GetColorByFormattedChar(char input, Color defaultcolor)
        {
            switch (input)
            {
                case '0':
                    return Color.Black;
                case '1':
                    return Color.DarkBlue;
                case '2':
                    return Color.DarkGreen;
                case '3':
                    return Color.DarkCyan;
                case '4':
                    return Color.DarkRed;
                case '5':
                    return Color.DarkMagenta;
                case '6':
                    return Color.Yellow;
                case '7':
                    return Color.Gray;
                case '8':
                    return Color.DarkGray;
                case '9':
                    return Color.Blue;
                case 'a':
                    return Color.Green;
                case 'b':
                    return Color.Cyan;
                case 'c':
                    return Color.Red;
                case 'd':
                    return Color.Magenta;
                case 'e':
                    return Color.LightGoldenrodYellow;
                case 'f':
                    return Color.White;
            }
            return defaultcolor;
        }
        public static char NormalizeFormattedChar(char input)
        {
            return Char.ToLower(input);
        }
    }
}