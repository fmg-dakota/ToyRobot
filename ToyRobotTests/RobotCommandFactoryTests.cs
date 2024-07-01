using ToyRobot;
using ToyRobot.Models;
using ToyRobot.RobotCommands;


namespace ToyRobotTests
{
    [TestClass]
    public class RobotCommandFactoryTests
    {
        private int _height = 5;
        private int _width = 5;


        private RobotCommandFactory SetupFactory()
        {
            Tabletop tabletop = new Tabletop(_width, _height);
            Robot robot = new Robot();
            UI ui = new UI();

            RobotCommandFactory commandFactory = new RobotCommandFactory(tabletop, robot, ui);

            return commandFactory;
        }

        [TestMethod]
        public void Place_ValidCmd()
        {
            RobotCommandFactory commandFactory = SetupFactory();

            string cmd = "PLACE 1,1,NORTH";

            IRobotCommand? robotCommand = commandFactory.BuildCommand(cmd);
            Assert.IsNotNull(robotCommand);
            Assert.IsInstanceOfType(robotCommand, typeof(Place));
        }

        [TestMethod]
        public void Place_ValidCmd_BoundaryValues()
        {
            RobotCommandFactory commandFactory = SetupFactory();

            string[] boundaryValues =
            {
                "PLACE 0,0,NORTH",
                "PLACE 0,4,NORTH",
                "PLACE 4,0,NORTH",
                "PLACE 4,4,NORTH"
            };

            foreach (string cmd in boundaryValues)
            {
                IRobotCommand? robotCommand = commandFactory.BuildCommand(cmd);
                Assert.IsNotNull(robotCommand);
                Assert.IsInstanceOfType(robotCommand, typeof(Place));
            }
        }

        [TestMethod]
        public void Place_InvalidCmd()
        {
            RobotCommandFactory commandFactory = SetupFactory();

            string cmd = "PLACE1, 6, NORTH";

            Assert.ThrowsException<ArgumentException>(() => commandFactory.BuildCommand(cmd));
        }

        [TestMethod]
        public void Place_InvalidCmd_InvalidDirection()
        {
            RobotCommandFactory commandFactory = SetupFactory();

            string cmd = "PLACE 1,6,WESTEAST";

            Assert.ThrowsException<ArgumentException>(() => commandFactory.BuildCommand(cmd));
        }

        [TestMethod]
        public void Place_InvalidCmd_InvalidXValue()
        {
            RobotCommandFactory commandFactory = SetupFactory();

            string cmd = "PLACE 100000000000000000000000000,1,NORTH";

            Assert.ThrowsException<ArgumentException>(() => commandFactory.BuildCommand(cmd));
        }

        [TestMethod]
        public void Place_InvalidCmd_InvalidYValue()
        {
            RobotCommandFactory commandFactory = SetupFactory();

            string cmd = "PLACE 1,100000000000000000000000000,NORTH";

            Assert.ThrowsException<ArgumentException>(() => commandFactory.BuildCommand(cmd));
        }

        [TestMethod]
        public void Move_ValidCmd()
        {
            RobotCommandFactory commandFactory = SetupFactory();

            string cmd = "MOVE";

            IRobotCommand? robotCommand = commandFactory.BuildCommand(cmd);
            Assert.IsNotNull(robotCommand);
            Assert.IsInstanceOfType(robotCommand, typeof(Move));
        }


        [TestMethod]
        public void Left_ValidCmd()
        {
            RobotCommandFactory commandFactory = SetupFactory();

            string cmd = "LEFT";

            IRobotCommand? robotCommand = commandFactory.BuildCommand(cmd);
            Assert.IsNotNull(robotCommand);
            Assert.IsInstanceOfType(robotCommand, typeof(TurnLeft));
        }

        [TestMethod]
        public void Right_ValidCmd()
        {
            RobotCommandFactory commandFactory = SetupFactory();

            string cmd = "RIGHT";

            IRobotCommand? robotCommand = commandFactory.BuildCommand(cmd);
            Assert.IsNotNull(robotCommand);
            Assert.IsInstanceOfType(robotCommand, typeof(TurnRight));
        }

        [TestMethod]
        public void InvalidCmd()
        {
            RobotCommandFactory commandFactory = SetupFactory();

            string cmd = "BLAH BLAH BLAH";

            Assert.ThrowsException<ArgumentException>(() => commandFactory.BuildCommand(cmd));
        }
    }
}