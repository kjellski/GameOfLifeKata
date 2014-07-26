using System;

namespace GameOfLife
{
    public class Dimensions : Tuple<int, int>
    {
        public Dimensions(int xSize, int ySize) : base(xSize, ySize)
        {
        }

        public int XSize
        {
            get { return Item1; }
        }

        public int YSize
        {
            get { return Item2; }
        }
    }
}