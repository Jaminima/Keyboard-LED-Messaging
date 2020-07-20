using LedCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LoveBoard
{
    public static class Effects
    {
        static Color[] CPalette = { Color.Red, Color.Green, Color.Blue, new Color(255,255,0), new Color(0, 255, 255), new Color(255, 0, 255) };

        public static void ColorSplosion(string Key, Color color, int spread=5, int millDelay = 100, Color FadeTo = null)
        {
            if (FadeTo == null) FadeTo = color;

            FadeTo.R = (color.R - FadeTo.R) / spread;
            FadeTo.G = (color.G - FadeTo.G) / spread;
            FadeTo.B = (color.B - FadeTo.B) / spread;

            int[] KeyPos = KeyControl.GetKeyPos(Key);

            for (int i = 0; spread - i > 0; i++)
            {
                //for (int y=KeyPos[0]-i,x=KeyPos[1]-i; y <= KeyPos[0] + i;)
                //{
                //    KeyControl.SetKey(x, y, color);
                //    x++;
                //    if (x > KeyPos[1] + i) { x = KeyPos[1] - i; y++; }
                //}

                int dx = 1, dy = 0;

                for (int y = KeyPos[0] - i, x = KeyPos[1] - i; ;)
                {
                    KeyControl.SetKey(x, y, color);

                    x += dx;
                    y += dy;

                    if (x > KeyPos[1] + i) { dx=0; dy=1; x--; }
                    if (y > KeyPos[0] + i) { dx=-1; dy = 0; y--; }
                    if (x < KeyPos[1] - i) { dx = 0; dy = -1; x++; }
                    if (y < KeyPos[0] - i) { break; }
                }

                Thread.Sleep(millDelay);
                color.R -= FadeTo.R;
                color.G -= FadeTo.G;
                color.B -= FadeTo.B;
            }
        }

        public static void RandomKeyColors(int repeat = 100, int millDelay = 5)
        {
            KeyControl.ResetBG();
            while (repeat>0)
            {
                KeyControl.SetKey(Program.rnd.Next(0, 21), Program.rnd.Next(0, 6), new Color(Program.rnd.Next(0, 255), Program.rnd.Next(0, 255), Program.rnd.Next(0, 255)));
                Thread.Sleep(millDelay);

                repeat--;
            }
        }

        public static void ShowText(string S)
        {
            Color col = null, prevCol = null;
            char PrevC = 'c';
            bool Clear = true;

            foreach (char C in S.ToUpper())
            {
                if (Clear) { KeyControl.ResetBG(); Thread.Sleep(100); Clear = false; }

                while (col == prevCol) col = CPalette[Program.rnd.Next(0, CPalette.Length)];

                if (PrevC!='c') KeyControl.SetKey(PrevC.ToString(), prevCol);

                if (C == ' ' || C == '\n') {
                    Clear = true;
                    prevCol = null;
                    PrevC = 'c';
                }
                else
                {
                    KeyControl.SetKey(C.ToString(), Color.White);
                    prevCol = col;
                    PrevC = C;
                }

                Thread.Sleep(800);
            }

            KeyControl.ResetBG();
        }
    }
}
