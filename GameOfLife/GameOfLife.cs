using System;

namespace GameOfLife
{
    public class GameOfLife
    {
        public const int XDimension = 1;
        public const int YDimension = 0;

        private readonly int _xSize;
        private readonly int _ySize;
        private bool[,] _land;

        public GameOfLife(int xSize, int ySize)
            : this(new bool[ySize, xSize])
        {
        }

        public GameOfLife(bool[,] land)
        {
            _xSize = land.GetLength(XDimension);
            _ySize = land.GetLength(YDimension);
            _land = land;
        }

        public bool[,] Land
        {
            get
            {
                var readCopy = new bool[_ySize, _xSize];
                Array.Copy(_land, readCopy, _land.Length);
                return readCopy;
            }
        }

        public void NextGeneration()
        {
            var result = new bool[_ySize, _xSize];
            for (var x = 0; x < _xSize; x++)
            {
                for (var y = 0; y < _ySize; y++)
                {
                    var cellNeighbours = CountNeighbours(x, y, _land);
                    ApplyRulesToCell(cellNeighbours, x, y, ref result);
                }
            }
            _land = result;
        }

        public static void ApplyRulesToCell(int cellNeighbours, int x, int y, ref bool[,] land)
        {
            var alive = IsCellAlive(x, y, land);
            var willLive = WillCellLive(alive, cellNeighbours);
            SetCell(x, y, ref land, willLive);
        }

        public static bool WillCellLive(bool alive, int cellNeighbours)
        {
            if (alive && cellNeighbours < 2) // any life cell with fewer then two live neighbours dies
                return false;

            if (alive && cellNeighbours > 3) // any life cell with more then three live neighbours dies
                return false;

            if (alive &&
                (cellNeighbours == 2 ||
                 cellNeighbours == 3)) // any life cell two or three live neighbours lives on
                return true;

            // any dead cell with exactly three live neighbours will live
            // all others stay dead
            return !alive && cellNeighbours == 3; 
        }

        public static void SetCell(int x, int y, ref bool[,] land, bool value)
        {
            land[y, x] = value;
        }

        public static int CountNeighbours(int x, int y, bool[,] land)
        {
            return
                GetCell(x - 1, y - 1, land) + GetCell(x + 0, y - 1, land) + GetCell(x + 1, y - 1, land) +
                GetCell(x - 1, y + 0, land) + /* the cell itself is here */ GetCell(x + 1, y + 0, land) +
                GetCell(x - 1, y + 1, land) + GetCell(x + 0, y + 1, land) + GetCell(x + 1, y + 1, land);
        }

        public static bool IsCellAlive(int x, int y, bool[,] land)
        {
            return GetCell(x, y, land) > 0;
        }

        public static int GetCell(int x, int y, bool[,] land)
        {
            if (x < 0 || x > land.GetLength(XDimension) - 1 || y < 0 || y > land.GetLength(YDimension))
            {
                return 0;
            }

            return land[y, x] ? 1 : 0;
        }
    }
}