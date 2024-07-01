using ToyRobot.Models;

namespace ToyRobotTests
{
    [TestClass]
    public class RobotTests
    {

        // Report
        [TestMethod]
        public void Report_ValidPosition()
        {
            Position position = new Position(1,1,Direction.NORTH);
            Robot robot = new Robot(position);

            string expectedReport = "1,1,NORTH";

            Assert.AreEqual(robot.Report(), expectedReport);
        }

        [TestMethod]
        public void Report_NoPosition()
        {
            Robot robot = new Robot();

            string expectedReport = "NO POSITION TO REPORT.";

            Assert.AreEqual(robot.Report(), expectedReport);
        }

        // GetRobotIcon
        [TestMethod]
        public void GetRobotIcon_North()
        {
            Position position = new Position(1,1, Direction.NORTH);
            Robot robot = new Robot(position);

            string expectedIcon = "▲";

            Assert.AreEqual(robot.GetRobotIcon(), expectedIcon);
        }

        [TestMethod]
        public void GetRobotIcon_South()
        {
            Position position = new Position(1, 1, Direction.SOUTH);
            Robot robot = new Robot(position);

            string expectedIcon = "▼";

            Assert.AreEqual(robot.GetRobotIcon(), expectedIcon);
        }

        [TestMethod]
        public void GetRobotIcon_East()
        {
            Position position = new Position(1, 1, Direction.EAST);
            Robot robot = new Robot(position);

            string expectedIcon = "►";

            Assert.AreEqual(robot.GetRobotIcon(), expectedIcon);
        }

        [TestMethod]
        public void GetRobotIcon_West()
        {
            Position position = new Position(1, 1, Direction.WEST);
            Robot robot = new Robot(position);

            string expectedIcon = "◄";

            Assert.AreEqual(robot.GetRobotIcon(), expectedIcon);
        }

        [TestMethod]
        public void GetRobotIcon_NoPosition()
        {
            Robot robot = new Robot();

            string expectedIcon = "?";

            Assert.AreEqual(robot.GetRobotIcon(), expectedIcon);
        }
    }
}
