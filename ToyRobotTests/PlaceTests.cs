using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Models;
using ToyRobot.RobotCommands;
using NuGet.Frameworks;

namespace ToyRobotTests
{
    [TestClass]
    public class PlaceTests
    {
        private Robot _robot;
        private Tabletop _tabletop;
        private Position _position;

        [TestInitialize]
        public void Setup()
        {
            _robot = new Robot();
            _tabletop = new Tabletop(5, 5);
        }

        [TestMethod]
        public void Place_InBounds_NotYetPlaced()
        {
            _position = new Position(1,1,Direction.NORTH);

            Place placeCommand = new Place(_tabletop, _robot, _position);
            placeCommand.execute();

            Assert.AreEqual(1, _robot.Position.X);
            Assert.AreEqual(1, _robot.Position.Y);
            Assert.AreEqual(Direction.NORTH, _robot.Position.Direction);
        }

        [TestMethod]
        public void Place_OutBounds_NotYetPlaced()
        {
            _position = new Position(10, 10, Direction.NORTH);

            Place placeCommand = new Place(_tabletop, _robot, _position);
            placeCommand.execute();

            Assert.IsNull(_robot.Position);
        }

        [TestMethod]
        public void Place_InBounds_AlreadyPlaced()
        {
            Position alreadyPlacedPos = new Position(2,2,Direction.NORTH);
            _robot.Position = alreadyPlacedPos;

            _position = new Position(1, 1, Direction.NORTH);

            Place placeCommand = new Place(_tabletop, _robot, _position);
            placeCommand.execute();

            Assert.AreEqual(1, _robot.Position.X);
            Assert.AreEqual(1, _robot.Position.Y);
            Assert.AreEqual(Direction.NORTH, _robot.Position.Direction);
        }

        [TestMethod]
        public void Place_OutBounds_AlreadyPlaced()
        {
            Position alreadyPlacedPos = new Position(2, 2, Direction.NORTH);
            _robot.Position = alreadyPlacedPos;

            _position = new Position(10, 10, Direction.NORTH);

            Place placeCommand = new Place(_tabletop, _robot, _position);
            placeCommand.execute();

            Assert.AreEqual(2, _robot.Position.X);
            Assert.AreEqual(2, _robot.Position.Y);
            Assert.AreEqual(Direction.NORTH, _robot.Position.Direction);
        }


    }
}
