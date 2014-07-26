﻿using System;
using System.Threading;

namespace ConsoleTesting
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var land = GameOfLife.GameOfLifeStringReader.Read(
@"....................................................
....................................................
....................................................
....................................................
....................................................
..........................*.*.......................
..........................***.......................
...........................*........................
..........................***.......................
..........................*.*.......................
....................................................
............*.......................................
...........***......................................
............*.......................................
....................................................
....................................................
....................................................
.................................**.................
................................****................
....................................................
....................................................
....................................................
....................................................
...................................................."
                );

            var gof = new GameOfLife.GameOfLife(land);

            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine(gof);
                gof.NextGeneration();
                Thread.Sleep(500);
            }
        }
    }
}