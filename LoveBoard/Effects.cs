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

        public static void ShowText(string S)
        {
            Color col = null, prevCol = null;
            char PrevC = 'c';
            bool Clear = false;

            foreach (char C in S.ToUpper())
            {
                if (Clear) { KeyControl.Clear(0, 0, 0); Thread.Sleep(100); Clear = false; }

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

            KeyControl.Clear(0, 0, 0);
        }
    }
}
