using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using LedCSharp;

namespace LoveBoard
{
    public static class KeyControl
    {
        public static keyboardNames[,] KeyGrid = new keyboardNames[,]
        {
            { keyboardNames.ESC, keyboardNames.F1, keyboardNames.F1,keyboardNames.F2,keyboardNames.F3,keyboardNames.F4, 00, keyboardNames.F5, keyboardNames.F6, keyboardNames.F7, keyboardNames.F8, 00, keyboardNames.F9, keyboardNames.F10, keyboardNames.F11, keyboardNames.F11, keyboardNames.F12, keyboardNames.PRINT_SCREEN, keyboardNames.SCROLL_LOCK, keyboardNames.PAUSE_BREAK, 00   },
            { keyboardNames.TILDE, keyboardNames.ONE, keyboardNames.TWO, keyboardNames.THREE, keyboardNames.FOUR, keyboardNames.FIVE, keyboardNames.SIX, keyboardNames.SEVEN, keyboardNames.EIGHT, keyboardNames.NINE, keyboardNames.ZERO, keyboardNames.MINUS, keyboardNames.EQUALS, keyboardNames.BACKSPACE, keyboardNames.INSERT, keyboardNames.HOME, keyboardNames.PAGE_UP, keyboardNames.NUM_LOCK, keyboardNames.NUM_SLASH, keyboardNames.NUM_ASTERISK, keyboardNames.NUM_MINUS },
            { keyboardNames.TAB, keyboardNames.Q, keyboardNames.W, keyboardNames.E, keyboardNames.R, keyboardNames.T, keyboardNames.Y, keyboardNames.U, keyboardNames.I, keyboardNames.O, keyboardNames.P, keyboardNames.OPEN_BRACKET, keyboardNames.CLOSE_BRACKET, keyboardNames.ENTER, keyboardNames.KEYBOARD_DELETE, keyboardNames.END, keyboardNames.PAGE_DOWN, keyboardNames.NUM_SEVEN, keyboardNames.NUM_EIGHT, keyboardNames.NUM_NINE, keyboardNames.NUM_PLUS },
            { keyboardNames.CAPS_LOCK, keyboardNames.A, keyboardNames.S, keyboardNames.D, keyboardNames.F, keyboardNames.G, keyboardNames.H, keyboardNames.J, keyboardNames.K, keyboardNames.L, keyboardNames.SEMICOLON, keyboardNames.APOSTROPHE, (keyboardNames)93, keyboardNames.ENTER, 00, 00, 00, keyboardNames.NUM_FOUR, keyboardNames.NUM_FIVE, keyboardNames.NUM_SIX, keyboardNames.NUM_PLUS },
            { keyboardNames.LEFT_SHIFT, (keyboardNames)86, keyboardNames.Z, keyboardNames.X, keyboardNames.C, keyboardNames.V, keyboardNames.B, keyboardNames.N, keyboardNames.M, keyboardNames.COMMA, keyboardNames.PERIOD, keyboardNames.FORWARD_SLASH, keyboardNames.RIGHT_SHIFT, keyboardNames.RIGHT_SHIFT, 00, keyboardNames.ARROW_UP, 00, keyboardNames.NUM_ONE, keyboardNames.NUM_TWO, keyboardNames.NUM_THREE, keyboardNames.NUM_ENTER },
            { keyboardNames.LEFT_CONTROL, keyboardNames.LEFT_WINDOWS, keyboardNames.LEFT_ALT, keyboardNames.SPACE, keyboardNames.SPACE, keyboardNames.SPACE, keyboardNames.SPACE, keyboardNames.SPACE, keyboardNames.SPACE, keyboardNames.SPACE, keyboardNames.RIGHT_ALT, keyboardNames.RIGHT_WINDOWS, keyboardNames.APPLICATION_SELECT, keyboardNames.RIGHT_CONTROL, keyboardNames.ARROW_LEFT, keyboardNames.ARROW_DOWN, keyboardNames.ARROW_RIGHT, keyboardNames.NUM_ZERO, keyboardNames.NUM_ZERO, keyboardNames.NUM_PERIOD, keyboardNames.NUM_ENTER }
        };

        public static void Start(int R=255, int G=255, int B=255)
        {
            LogitechGSDK.LogiLedInit();

            LogitechGSDK.LogiLedSaveCurrentLighting();
            LogitechGSDK.LogiLedSetLighting(R, G, B);
            LogitechGSDK.LogiLedRestoreLighting();
        }

        public static void DrawColorGrid(int[,,] Pos, int XOffset)
        {
            for (int x = 0, y = 0; y < 6;)
            {
                SetKey(x+XOffset, y, (int[])Pos.GetValue(x, y));
                x++;
                if (x == Pos.GetLength(0)) { y++; x = 0; }
            }
        }

        public static void SetKey(int x, int y, int[] Colors)
        {
            LogitechGSDK.LogiLedSetLightingForKeyWithKeyName(KeyGrid[y, x], Colors[0], Colors[1], Colors[2]);
        }
    }
}
