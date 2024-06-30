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
    public class TurnLeftTests
    {
        private Robot _robot;

        [TestInitialize]
        public void Setup()
        {
            _robot = new Robot();
        }

        [TestMethod]
        public void TurnLeft_ValidPosition_FacingNorth()
        {
            _robot.Position = new Position(1, 1, Direction.NORTH);

            TurnLeft turnCommand = new TurnLeft(_robot);
            turnCommand.execute();

            Assert.AreEqual(1, _robot.Position.X);
            Assert.AreEqual(1, _robot.Position.Y);
            Assert.AreEqual(Direction.WEST, _robot.Position.Direction);
        }

        [TestMethod]
        public void TurnLeft_ValidPosition_FacingSouth()
        {
            _robot.Position = new Position(1, 1, Direction.SOUTH);

            TurnLeft turnCommand = new TurnLeft(_robot);
            turnCommand.execute();

            Assert.AreEqual(1, _robot.Position.X);
            Assert.AreEqual(1, _robot.Position.Y);
            Assert.AreEqual(Direction.EAST, _robot.Position.Direction);
        }

        [TestMethod]
        public void TurnLeft_ValidPosition_FacingEast()
        {
            _robot.Position = new Position(1, 1, Direction.EAST);

            TurnLeft turnCommand = new TurnLeft(_robot);
            turnCommand.execute();

            Assert.AreEqual(1, _robot.Position.X);
            Assert.AreEqual(1, _robot.Position.Y);
            Assert.AreEqual(Direction.NORTH, _robot.Position.Direction);
        }

        [TestMethod]
        public void TurnLeft_ValidPosition_FacingWest()
        {
            _robot.Position = new Position(1, 1, Direction.WEST);

            TurnLeft turnCommand = new TurnLeft(_robot);
            turnCommand.execute();

            Assert.AreEqual(1, _robot.Position.X);
            Assert.AreEqual(1, _robot.Position.Y);
            Assert.AreEqual(Direction.SOUTH, _robot.Position.Direction);
        }

        [TestMethod]
        public void TurnLeft_NullPosition()
        {
            _robot.Position = null;

            TurnLeft turnCommand = new TurnLeft(_robot);
            turnCommand.execute();

            Assert.IsNull(_robot.Position);
        }

        [TestMethod]
        public void Turn_NullRobot_Left()
        {
            _robot = null;

            TurnLeft turnCommand = new TurnLeft(_robot);
            turnCommand.execute();

            Assert.IsNull(_robot);
        }
    }
}
