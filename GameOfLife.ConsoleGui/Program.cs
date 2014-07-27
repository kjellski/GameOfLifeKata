using System;
using System.Threading;
using GameOfLife.Core;

namespace GameOfLife.ConsoleGui
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var land = GameOfLifeStringReader.Read(ExampleLands.Land1);

            var gof = new Core.GameOfLife(land);
            Console.WriteLine();
            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine(gof);
                gof.NextGeneration();
                Thread.Sleep(500);
            }
        }
    }
}
