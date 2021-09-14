using GolDll;

using System;
using System.Diagnostics;

namespace GolConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var g = new GameOfLife(32,32);

            g.RandomizeLivingCells();           

            //for (int i = 0; i < 10; i++)
            //{
            //    g.SetAliveCell(i,i);
            //    g.SetAliveCell(i, i + 1);
            //    g.SetAliveCell(i, i - 1);
            //}


            Console.Write(g.ToString());

            for (int i = 0; i < 100; i++)
            {
                System.Threading.Thread.Sleep(100);
                g.generateNextStep();
                
                Console.Clear();
                Console.Write(g.ToString());    
            }
            Console.Write(g.ToString());
            Console.Clear();

        }
    }
}
