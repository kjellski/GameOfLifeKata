using NUnit.Framework;

namespace GameOfLife.Tests
{
    [TestFixture]
    public class GameOfLifeTests
    {
        [Test]
        public void CountNeighbours_Counts_Right_In_Corner()
        {
            // arrange
            // act
            // assert
            Assert.That(GameOfLife.CountNeighbours(0, 0, new[,]
            {
                {true, false},
                {true, false}
            }), Is.EqualTo(1));

            Assert.That(GameOfLife.CountNeighbours(0, 0, new[,]
            {
                {true, true},
                {true, false}
            }), Is.EqualTo(2));

            Assert.That(GameOfLife.CountNeighbours(0, 0, new[,]
            {
                {true, true},
                {true, true}
            }), Is.EqualTo(3));
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
        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [TestCase(int.MaxValue, 0)]
        [TestCase(0, int.MaxValue)]
        public void GetCell_When_X_Or_Y_Out_Of_Bounds(int x, int y)
        {
            // arrange
            var land = new[,]
            {
                {false, false},
                {false, false}
            };

            // act
            // assert
            Assert.That(() => GameOfLife.GetCell(x, y, land), Throws.Nothing);
        }
        
        [Test]
        public void IsCellAlive()
        {
            // arrange
            var land = new[,]
            {
                {true, false}
            };
            // act 
            // assert
            Assert.That(GameOfLife.IsCellAlive(0, 0, land), Is.True);
            Assert.That(GameOfLife.IsCellAlive(1, 0, land), Is.False);
        }

        [Test]
        public void LandProperty_Returns_A_ReadCopy()
        {
            // arrange
            var gol = new GameOfLife(new[,]
            {
                {false, false},
                {false, false}
            });
            // act 
            var copy = gol.Land;
            copy[0, 0] = true;

            // assert
            Assert.That(copy[0, 0], Is.True);
            Assert.That(gol.Land[0, 0], Is.False);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        [TestCase(1, 1)]
        public void SetCell_Sets_Value_In_Cell(int x, int y)
        {
            // arrange
            var land = new[,]
            {
                {false, false},
                {false, false}
            };
            const bool value = true;

            // act 
            GameOfLife.SetCell(x, y, ref land, value);

            // assert
            Assert.That(GameOfLife.IsCellAlive(x, y, land), Is.EqualTo(value));
        }

        [Test]
        [TestCase(true, 0, false)] /*  rule 1*/
        [TestCase(true, 1, false)] /*  rule 1*/
        [TestCase(true, 2, true)] /*   rule 3*/
        [TestCase(true, 3, true)] /*   rule 3*/
        [TestCase(true, 4, false)] /*  rule 2*/
        [TestCase(true, 5, false)] /*  rule 2*/
        [TestCase(false, 0, false)] /* rule implicit*/
        [TestCase(false, 1, false)] /* rule implicit*/
        [TestCase(false, 2, false)] /* rule implicit*/
        [TestCase(false, 3, true)] /*  rule 4*/
        [TestCase(false, 4, false)] /* rule implicit*/
        public void WillCellLive_Applies_Game_Of_Life_Rules(bool alive, int neighbours, bool willLive)
        {
            // arrange
            // act 
            // assert
            Assert.That(GameOfLife.WillCellLive(alive, neighbours), Is.EqualTo(willLive));
        }
    }
}