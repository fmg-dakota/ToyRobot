using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Models;
using ToyRobot.RobotCommands;

namespace ToyRobotTests
{
    [TestClass]
    public class MoveTests
    {
        private Tabletop _tabletop;
        private Robot _robot;

        [TestInitialize]
        public void Setup()
        {
            _tabletop = new Tabletop(5, 5);
            _robot = new Robot();
        }

        [TestMethod]
        public void Move_RobotHasNullPosition()
        {
            _robot.Position = null;

            Move moveCommand = new Move(_tabletop, _robot);
            moveCommand.execute();

            Assert.IsNull(_robot.Position);
        }

        [TestMethod]
        public void Move_InBounds_North()
        {
            _robot.Position = new Position(2, 2, Direction.NORTH);

            Move moveCommand = new Move(_tabletop, _robot);
            moveCommand.execute();

            Assert.AreEqual(2, _robot.Position.X);
            Assert.AreEqual(3, _robot.Position.Y);
            Assert.AreEqual(Direction.NORTH, _robot.Position.Direction);
        }

        [TestMethod]
        public void Move_InBounds_South()
        {
            _robot.Position = new Position(2, 2, Direction.SOUTH);

            Move moveCommand = new Move(_tabletop, _robot);
            moveCommand.execute();

            Assert.AreEqual(2, _robot.Position.X);
            Assert.AreEqual(1, _robot.Position.Y);
            Assert.AreEqual(Direction.SOUTH, _robot.Position.Direction);
        }

        [TestMethod]
        public void Move_InBounds_East()
        {
            _robot.Position = new Position(2, 2, Direction.EAST);

            Move moveCommand = new Move(_tabletop, _robot);
            moveCommand.execute();

            Assert.AreEqual(3, _robot.Position.X);
            Assert.AreEqual(2, _robot.Position.Y);
            Assert.AreEqual(Direction.EAST, _robot.Position.Direction);
        }

        [TestMethod]
        public void Move_InBounds_West()
        {
            _robot.Position = new Position(2, 2, Direction.WEST);

            Move moveCommand = new Move(_tabletop, _robot);
            moveCommand.execute();

            Assert.AreEqual(1, _robot.Position.X);
            Assert.AreEqual(2, _robot.Position.Y);
            Assert.AreEqual(Direction.WEST, _robot.Position.Direction);
        }

        [TestMethod]
        public void Move_OutOfBounds_North()
        {
            _robot.Position = new Position(2, 4, Direction.NORTH);

            Move moveCommand = new Move(_tabletop, _robot);
            moveCommand.execute();

            Assert.AreEqual(2, _robot.Position.X);
            Assert.AreEqual(4, _robot.Position.Y);
            Assert.AreEqual(Direction.NORTH, _robot.Position.Direction);
        }

        [TestMethod]
        public void Move_OutOfBounds_South()
        {
            _robot.Position = new Position(2, 0, Direction.SOUTH);

            Move moveCommand = new Move(_tabletop, _robot);
            moveCommand.execute();

            Assert.AreEqual(2, _robot.Position.X);
            Assert.AreEqual(0, _robot.Position.Y);
            Assert.AreEqual(Direction.SOUTH, _robot.Position.Direction);
        }

        [TestMethod]
        public void Move_OutOfBounds_East()
        {
            _robot.Position = new Position(4, 2, Direction.EAST);

            Move moveCommand = new Move(_tabletop, _robot);
            moveCommand.execute();

            Assert.AreEqual(4, _robot.Position.X);
            Assert.AreEqual(2, _robot.Position.Y);
            Assert.AreEqual(Direction.EAST, _robot.Position.Direction);
        }

        [TestMethod]
        public void Move_OutOfBounds_West()
        {
            _robot.Position = new Position(0, 2, Direction.WEST);

            Move moveCommand = new Move(_tabletop, _robot);
            moveCommand.execute();

            Assert.AreEqual(0, _robot.Position.X);
            Assert.AreEqual(2, _robot.Position.Y);
            Assert.AreEqual(Direction.WEST, _robot.Position.Direction);
        }
    }
}
