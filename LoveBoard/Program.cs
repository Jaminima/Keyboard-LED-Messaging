using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml.Schema;
using LedCSharp;

namespace LoveBoard
{
    class Program
    {
        public static Random rnd = new Random();

        static void Main(string[] args)
        {

            KeyControl.Start();

            Effects.ColorSplosion("H", Color.Red, 5,200, new Color(100,100,0));

            //Effects.RandomKeyColors(500);

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

            //Effects.ShowText(@"I Love You So Much");

            Console.ReadLine();

            LogitechGSDK.LogiLedShutdown();

        }
    }
}
