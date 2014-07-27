using System;
using System.Linq;

namespace GameOfLife.Core
{
    public static class GameOfLifeStringReader
    {
        public static bool[,] Read(String land)
        {
            var lines = land.Split('\n').Where(line => line.Length > 1).ToArray();
            var result = new bool[lines.Length, lines[0].Length]; 
            for (var y = 0; y < lines.Length; y++)
            {
                var line = lines[y];
                for (var x = 0; x < line.Length; x++)
                {
                    var value = line[x] == '*';
                    GameOfLife.SetCell(x, y, ref result, value);
                }
            }
            return result;
        }
    }
}