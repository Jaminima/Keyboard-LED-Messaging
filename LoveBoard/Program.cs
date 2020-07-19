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

            KeyControl.Start();

            while (true)
            {
                KeyControl.SetKey(rnd.Next(0, 21), rnd.Next(0, 6), new int[] { rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255) });
                Thread.Sleep(5);
            }

            Console.ReadLine();

            LogitechGSDK.LogiLedShutdown();

        }
    }
}
