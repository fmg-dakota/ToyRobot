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
    public class TurnRightTests
    {
        private Robot _robot;

        [TestInitialize]
        public void Setup()
        {
            _robot = new Robot();
        }

        [TestMethod]
        public void TurnRight_ValidPosition_FacingNorth()
        {
            _robot.Position = new Position(1, 1, Direction.NORTH);

            TurnRight turnCommand = new TurnRight(_robot);
            turnCommand.execute();

            Assert.AreEqual(1, _robot.Position.X);
            Assert.AreEqual(1, _robot.Position.Y);
            Assert.AreEqual(Direction.EAST, _robot.Position.Direction);
        }

        [TestMethod]
        public void TurnRight_ValidPosition_FacingSouth()
        {
            _robot.Position = new Position(1, 1, Direction.SOUTH);

            TurnRight turnCommand = new TurnRight(_robot);
            turnCommand.execute();

            Assert.AreEqual(1, _robot.Position.X);
            Assert.AreEqual(1, _robot.Position.Y);
            Assert.AreEqual(Direction.WEST, _robot.Position.Direction);
        }

        [TestMethod]
        public void TurnRight_ValidPosition_FacingEast()
        {
            _robot.Position = new Position(1, 1, Direction.EAST);

            TurnRight turnCommand = new TurnRight(_robot);
            turnCommand.execute();

            Assert.AreEqual(1, _robot.Position.X);
            Assert.AreEqual(1, _robot.Position.Y);
            Assert.AreEqual(Direction.SOUTH, _robot.Position.Direction);
        }

        [TestMethod]
        public void TurnRight_ValidPosition_FacingWest()
        {
            _robot.Position = new Position(1, 1, Direction.WEST);

            TurnRight turnCommand = new TurnRight(_robot);
            turnCommand.execute();

            Assert.AreEqual(1, _robot.Position.X);
            Assert.AreEqual(1, _robot.Position.Y);
            Assert.AreEqual(Direction.NORTH, _robot.Position.Direction);
        }

        [TestMethod]
        public void TurnRight_NullPosition()
        {
            _robot.Position = null;

            TurnRight turnCommand = new TurnRight(_robot);
            turnCommand.execute();

            Assert.IsNull(_robot.Position);
        }

        [TestMethod]
        public void Turn_NullRobot_Right()
        {
            _robot = null;

            TurnRight turnCommand = new TurnRight(_robot);
            turnCommand.execute();

            Assert.IsNull(_robot);
        }
    }
}
