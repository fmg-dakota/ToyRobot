using NuGet.Frameworks;
using ToyRobot;
using ToyRobot.Models;
using ToyRobot.RobotCommands;

namespace ToyRobotTests
{
    [TestClass]
    public class TurnTests
    {
        private Robot _robot;
        private string _leftRight;

        [TestInitialize]
        public void Setup()
        {
            _robot = new Robot();
        }

        [TestMethod]
        public void Turn_ValidPosition_Right()
        {
            _robot.Position = new Position(1,1,Direction.NORTH);
            _leftRight = "RIGHT";

            Turn turnCommand = new Turn(_robot, _leftRight);
            turnCommand.execute();

            Assert.AreEqual(1, _robot.Position.X);
            Assert.AreEqual(1, _robot.Position.Y);
            Assert.AreEqual(Direction.EAST, _robot.Position.Direction);
        }

        [TestMethod]
        public void Turn_ValidPosition_Left()
        {
            _robot.Position = new Position(1, 1, Direction.NORTH);
            _leftRight = "LEFT";

            Turn turnCommand = new Turn(_robot, _leftRight);
            turnCommand.execute();

            Assert.AreEqual(1, _robot.Position.X);
            Assert.AreEqual(1, _robot.Position.Y);
            Assert.AreEqual(Direction.WEST, _robot.Position.Direction);
        }

        [TestMethod]
        public void Turn_NullPosition_Right()
        {
            _robot.Position = null;
            _leftRight = "RIGHT";

            Turn turnCommand = new Turn(_robot, _leftRight);
            turnCommand.execute();

            Assert.IsNull(_robot.Position);
        }

        [TestMethod]
        public void Turn_NullPosition_Left()
        {
            _robot.Position = null;
            _leftRight = "LEFT";

            Turn turnCommand = new Turn(_robot, _leftRight);
            turnCommand.execute();

            Assert.IsNull(_robot.Position);
        }

        [TestMethod]
        public void Turn_NullRobot_Right()
        {
            _robot = null;
            _leftRight = "RIGHT";

            Turn turnCommand = new Turn(_robot, _leftRight);
            turnCommand.execute();

            Assert.IsNull(_robot);
        }

        [TestMethod]
        public void Turn_NullRobot_Left()
        {
            _robot = null;
            _leftRight = "LEFT";

            Turn turnCommand = new Turn(_robot, _leftRight);
            turnCommand.execute();

            Assert.IsNull(_robot);
        }
    }
}
