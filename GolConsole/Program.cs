using GolDll;

using System;

namespace GolConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
            var g = new GameOfLife(20, 20);

            g.RandomizeLivingCells();

            Console.Write(g.ToString());
            Console.CursorVisible = false;


            for (int i = 0; i < 1000; i++)
            {
                Console.SetCursorPosition(0, 0);
                g.generateNextStep();
                Console.Write(g.ToString());
                System.Threading.Thread.Sleep(1000);
            }

            Console.Write(g.ToString());
            Console.Clear();

        }
    }
}
