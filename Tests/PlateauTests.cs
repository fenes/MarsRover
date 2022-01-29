using Domain.Types;
using NUnit.Framework;


namespace Tests
{
    [TestFixture]
    public class PlateauTests
    {
        [Test]
        public void Test_Plateau_Constructor()
        {
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            Assert.AreEqual(5, plateau.Coordinate.X);
            Assert.AreEqual(5, plateau.Coordinate.Y);
        }

        [Test]
        public void Test_Plateau_IsValidPosition()
        {
            Plateau plateau = new Plateau(new Coordinate(5, 5));
            Assert.IsTrue(plateau.IsValidPosition(new Coordinate(1, 2)));
            Assert.IsTrue(plateau.IsValidPosition(new Coordinate(5, 5)));
            Assert.IsFalse(plateau.IsValidPosition(new Coordinate(6, 5)));
            Assert.IsFalse(plateau.IsValidPosition(new Coordinate(5, 6)));
            Assert.IsTrue(plateau.IsValidPosition(new Coordinate(0, 0)));
            Assert.IsTrue(plateau.IsValidPosition(new Coordinate(0, 5)));
            Assert.IsTrue(plateau.IsValidPosition(new Coordinate(5, 0)));
        }
    }
}