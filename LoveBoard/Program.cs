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

            //char prev='c';
            //foreach (char C in "Hello There".ToUpper())
            //{
            //    KeyControl.Clear(0, 0, 0);
            //    Thread.Sleep(50);

            //    if (prev!='c') KeyControl.SetKey(prev.ToString(), new Color(255, 125, 125));
            //    KeyControl.SetKey(C.ToString(), Color.Red);
            //    prev = C;

            //    Thread.Sleep(500);
            //}

            Effects.ShowText(@"What memories have been,
Now keep the heart warm,
Holds you in happiness,
When the worlds out of form.

The success in the past,
Gives us the strength to raise the mast,
To set a course,
To fill our sails without ghast.

Our love in our time,
Fills our heart with desire devine,
Pushes us to make a world finer than wine,
To bathe in a bond that'll face all of time.

Dreams of what can be,
Strengths the bond between you and me,
Builds a world to desire,
One where our souls are on fire.

The day that it will be,
Is not far along the bend,
To times inseperable, 
In a perfect lovey dovey blend");

            Console.ReadLine();

            LogitechGSDK.LogiLedShutdown();

        }
    }
}
