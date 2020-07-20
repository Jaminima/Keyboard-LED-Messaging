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
            { keyboardNames.ESC, keyboardNames.F1, keyboardNames.F1,keyboardNames.F2,keyboardNames.F3,keyboardNames.F4, keyboardNames.F5, keyboardNames.F6, keyboardNames.F7, keyboardNames.F8, 00, keyboardNames.F9, keyboardNames.F10, keyboardNames.F11,  keyboardNames.F12, keyboardNames.PRINT_SCREEN, keyboardNames.SCROLL_LOCK, keyboardNames.PAUSE_BREAK, 00, 00, 00  },
            { keyboardNames.TILDE, keyboardNames.ONE, keyboardNames.TWO, keyboardNames.THREE, keyboardNames.FOUR, keyboardNames.FIVE, keyboardNames.SIX, keyboardNames.SEVEN, keyboardNames.EIGHT, keyboardNames.NINE, keyboardNames.ZERO, keyboardNames.MINUS, keyboardNames.EQUALS, keyboardNames.BACKSPACE, keyboardNames.INSERT, keyboardNames.HOME, keyboardNames.PAGE_UP, keyboardNames.NUM_LOCK, keyboardNames.NUM_SLASH, keyboardNames.NUM_ASTERISK, keyboardNames.NUM_MINUS },
            { keyboardNames.TAB, keyboardNames.Q, keyboardNames.W, keyboardNames.E, keyboardNames.R, keyboardNames.T, keyboardNames.Y, keyboardNames.U, keyboardNames.I, keyboardNames.O, keyboardNames.P, keyboardNames.OPEN_BRACKET, keyboardNames.CLOSE_BRACKET, keyboardNames.ENTER, keyboardNames.KEYBOARD_DELETE, keyboardNames.END, keyboardNames.PAGE_DOWN, keyboardNames.NUM_SEVEN, keyboardNames.NUM_EIGHT, keyboardNames.NUM_NINE, keyboardNames.NUM_PLUS },
            { keyboardNames.CAPS_LOCK, keyboardNames.A, keyboardNames.S, keyboardNames.D, keyboardNames.F, keyboardNames.G, keyboardNames.H, keyboardNames.J, keyboardNames.K, keyboardNames.L, keyboardNames.SEMICOLON, keyboardNames.APOSTROPHE, (keyboardNames)93, keyboardNames.ENTER, 00, 00, 00, keyboardNames.NUM_FOUR, keyboardNames.NUM_FIVE, keyboardNames.NUM_SIX, keyboardNames.NUM_PLUS },
            { keyboardNames.LEFT_SHIFT, (keyboardNames)86, keyboardNames.Z, keyboardNames.X, keyboardNames.C, keyboardNames.V, keyboardNames.B, keyboardNames.N, keyboardNames.M, keyboardNames.COMMA, keyboardNames.PERIOD, keyboardNames.FORWARD_SLASH, keyboardNames.RIGHT_SHIFT, keyboardNames.RIGHT_SHIFT, 00, keyboardNames.ARROW_UP, 00, keyboardNames.NUM_ONE, keyboardNames.NUM_TWO, keyboardNames.NUM_THREE, keyboardNames.NUM_ENTER },
            { keyboardNames.LEFT_CONTROL, keyboardNames.LEFT_WINDOWS, keyboardNames.LEFT_ALT, keyboardNames.SPACE, keyboardNames.SPACE, keyboardNames.SPACE, keyboardNames.SPACE, keyboardNames.SPACE, keyboardNames.SPACE, keyboardNames.SPACE, keyboardNames.RIGHT_ALT, keyboardNames.RIGHT_WINDOWS, keyboardNames.APPLICATION_SELECT, keyboardNames.RIGHT_CONTROL, keyboardNames.ARROW_LEFT, keyboardNames.ARROW_DOWN, keyboardNames.ARROW_RIGHT, keyboardNames.NUM_ZERO, keyboardNames.NUM_ZERO, keyboardNames.NUM_PERIOD, keyboardNames.NUM_ENTER }
        };
        public static Color BGcolor = Color.Black;

        public static void Start(Color color = null)
        {
            LogitechGSDK.LogiLedInit();
            LogitechGSDK.LogiLedSaveCurrentLighting();

            if (color != null) BGcolor = color;
            ResetBG();

            LogitechGSDK.LogiLedRestoreLighting();
        }

        public static void ResetBG()
        {
            LogitechGSDK.LogiLedSetLighting(BGcolor.R, BGcolor.G,BGcolor.B);
        }

        public static void DrawColorGrid(Color[,] Pos, int XOffset)
        {
            for (int x = 0, y = 0; y < 6;)
            {
                SetKey(x+XOffset, y, Pos[y, x]);
                x++;
                if (x == Pos.GetLength(1)) { y++; x = 0; }
            }
        }

        public static keyboardNames GetKey(string C)
        {
            if (C == " ") { C = "SPACE"; }

            keyboardNames k;
            if (Enum.TryParse(C, out k))
            {
                return k;
            }

            return 00;
        }

        public static int[] GetKeyPos(string C)
        {
            if (C == " ") { C = "SPACE"; }

            keyboardNames k;
            if (Enum.TryParse(C, out k))
            {
                for (int x = 0, y = 0; y < 6;)
                {
                    if (KeyGrid[y, x] == k) { return new int[] { y,x }; }
                    x++;
                    if (x == 21) { y++; x = 0; }
                }
            }

            return null;
        }

        public static void SetKey(string C, Color Color)
        {
            LogitechGSDK.LogiLedSetLightingForKeyWithKeyName(GetKey(C), Color.R, Color.G, Color.B);
        }

        public static void SetKey(int x, int y, Color Color)
        {
            if (x<21&&y<6&&x>=0&&y>=0) LogitechGSDK.LogiLedSetLightingForKeyWithKeyName(KeyGrid[y, x], Color.R, Color.G, Color.B);
        }
    }

    public class Color
    {
        public int R, G, B;

        public Color(int R, int G, int B)
        {
            this.R = R;
            this.G = G;
            this.B = B;
        }

        public static Color Red = new Color(255, 0, 0);
        public static Color Green = new Color(0, 255, 0);
        public static Color Blue = new Color(0, 0, 255);
        public static Color Black = new Color(0, 0, 0);
        public static Color White = new Color(255, 255, 255);
    }
}
