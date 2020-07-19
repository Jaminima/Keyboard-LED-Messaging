using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using LedCSharp;

namespace LoveBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            KeyControl.Start(0,0,0);

            //while (true)
            //{
            //    KeyControl.SetKey(rnd.Next(0, 21), rnd.Next(0, 6), new int[] { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) });
            //    Thread.Sleep(5);
            //}

            //for (int i = 21; i > -10; i--)
            //{
            //    KeyControl.DrawColorGrid(new Color[,] {
            //        { Color.Black,Color.Black,Color.Black,Color.Black,Color.Black },
            //        { Color.Black,Color.Red,Color.Black,Color.Red,Color.Black },
            //        { Color.Red,Color.Black,Color.Red,Color.Black,Color.Red },
            //        { Color.Red,Color.Black,Color.Black,Color.Red,Color.Black },
            //        { Color.Black,Color.Red,Color.Red,Color.Black,Color.Black },
            //        { Color.Black,Color.Black,Color.Red,Color.Black,Color.Black }
            //    }, i);
            //    Thread.Sleep(500);
            //    KeyControl.Clear(0, 0, 0);
            //}

            foreach (char C in "Hello There".ToUpper())
            {
                KeyControl.Clear(0, 0, 0);
                Thread.Sleep(50);
                KeyControl.SetKey(C.ToString(), Color.Blue);
                Thread.Sleep(500);
            }

            Console.ReadLine();

            LogitechGSDK.LogiLedShutdown();

        }
    }
}
