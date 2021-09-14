using GolDll;

using System;
using System.Diagnostics;

namespace GolConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new GameOfLife(20,20);

            g.RandomizeLivingCells();           



            Console.Write(g.ToString());
            Console.CursorVisible = false;

            for (int i = 0; i < 1000; i++)
            {
                Console.SetCursorPosition(0, 0);
                //var sw = new Stopwatch();   
                //sw.Start(); 
                g.generateNextStep();
                //Console.WriteLine(sw.Elapsed.ToString());
                //Console.SetCursorPosition(0, 32*i);
                Console.Write(g.ToString());

                System.Threading.Thread.Sleep(1000);
            }

            Console.Write(g.ToString());
            Console.Clear();

        }
    }
}
