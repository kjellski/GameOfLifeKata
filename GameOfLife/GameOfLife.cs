namespace GameOfLife
{
    public class GameOfLife
    {
        public const int XDimension = 1;
        public const int YDimension = 0;
        private readonly bool[,] _land;

        private readonly int _xSize;
        private readonly int _ySize;

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

        //public bool[,] NextGeneration()
        //{
        //    for (int x = 0; x < _xSize; x++)
        //    {
        //        for (int y = 0; y < _ySize; y++)
        //        {
        //            var cellNeighbours = CountNeighbours(x,y,_land);
        //        }
        //    }
        //}

        //public static int CountNeighbours(int x, int y, bool[,] land)
        //{
        //    var result = 0;
        //    return GetCell(x-1,y-1,land) 
        //}

        public Dimensions GetDimensions()
        {
            return new Dimensions(_land.GetLength(XDimension), _land.GetLength(YDimension));
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