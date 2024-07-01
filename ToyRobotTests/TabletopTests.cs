using ToyRobot.Models;

namespace ToyRobotTests
{
    [TestClass]
    public class TabletopTests
    {

        private int _height = 5;
        private int _width = 5;

        private Tabletop SetupTabletop()
        {
            return new Tabletop(_width, _height);
        }

        [TestMethod]
        public void IsValidPosition_ValidPosition()
        {
            Tabletop tabletop = SetupTabletop();

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    Position position = new Position(x, y, Direction.NORTH);
                    Assert.IsTrue(tabletop.IsValidPosition(position));
                }
            }
        }

        [TestMethod]
        public void IsValidPosition_InvalidPosition()
        {
            Tabletop tabletop = SetupTabletop();

            Position[] invalidPositions =
            {
                new Position(-1, -1, Direction.NORTH),
                new Position(5, 5, Direction.NORTH),
            };

            foreach (Position position in invalidPositions)
            {
                Assert.IsFalse(tabletop.IsValidPosition(position));
            }
        }
    }
}
