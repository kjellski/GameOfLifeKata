using System;
using NUnit.Framework;
using GameOfLife;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class GameOfLifeTests
    {
        private const int YSize = 2;
        private const int XSize = 2;

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [TestCase(int.MaxValue, 0)]
        [TestCase(0, int.MaxValue)]
        public void GetCell_When_X_Or_Y_Out_Of_Bounds(int x, int y)
        {
            // arrange
            var land = new [,]
            {
                {false, false},
                {false, false}
            };

            // act
            // assert
            Assert.That(() => GameOfLife.GetCell(x, y, land), Throws.Nothing);
        }

        [Test]
        public void GetCell_Returns_One_For_Life_And_Zero_For_Dead_Cell()
        {
            // arrange
            var land = new[,]
            {
                {true, false},
                {true, false}
            };

            // act
            // assert
            Assert.That(GameOfLife.GetCell(0, 0, land), Is.EqualTo(1));
            Assert.That(GameOfLife.GetCell(0, 1, land), Is.EqualTo(1));
            Assert.That(GameOfLife.GetCell(1, 0, land), Is.EqualTo(0));
            Assert.That(GameOfLife.GetCell(1, 1, land), Is.EqualTo(0));
        }

        [Test]
        [TestCase(10, 1)]
        [TestCase(1, 10)]
        [TestCase(10, 10)]
        public void GetDimensions_Resolves_Dimensions(int xSize, int ySize)
        {
            // arrange
            var gof = new GameOfLife(xSize, ySize);

            // act
            var result = gof.GetDimensions();

            // assert
            Assert.That(result.XSize, Is.EqualTo(xSize));
            Assert.That(result.YSize, Is.EqualTo(ySize));
        }
    }
}