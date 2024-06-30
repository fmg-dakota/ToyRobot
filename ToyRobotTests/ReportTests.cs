using NuGet.Frameworks;
using System.Security.Cryptography.X509Certificates;
using ToyRobot;
using ToyRobot.Models;
using ToyRobot.RobotCommands;

namespace ToyRobotTests
{
    [TestClass]
    public class ReportTests
    {
        private Tabletop _tabletop;
        private Robot _robot;
        private TestUI _ui;


        [TestInitialize]
        public void Setup()
        {
            _tabletop = new Tabletop(5, 5);
            _robot = new Robot();
            _ui = new TestUI();
        }

        [TestMethod]
        public void Report_ValidPosition()
        {
            _robot.Position = new Position(1, 1, Direction.NORTH);

            Report report = new Report(_tabletop, _robot, _ui);

            string expectedReport = "1,1,NORTH";
            string expectedTabletopOutput = "[ ][ ][ ][ ][ ]\n[ ][ ][ ][ ][ ]\n[ ][ ][ ][ ][ ]\n[ ][▲][ ][ ][ ]\n[ ][ ][ ][ ][ ]";
            
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            report.execute();

            string output = stringWriter.ToString();
            stringWriter.Dispose();
            Console.SetOut(Console.Out);

            Assert.IsTrue(output.Contains(expectedReport));
            Assert.IsTrue(output.Contains(expectedTabletopOutput));
        }

        [TestMethod]
        public void Report_InvalidPosition()
        {
            _robot.Position = null;

            Report report = new Report(_tabletop, _robot, _ui);

            string expectedReport = "NO POSITION TO REPORT.";

            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            report.execute();

            string output = stringWriter.ToString();
            stringWriter.Dispose();
            Console.SetOut(Console.Out);

            Assert.IsTrue(output.Contains(expectedReport));
        }

        // Stub class so I can redirect the Console to a string writer
        private class TestUI : UI
        {
            public TestUI() { }

            public void PrintMessage(string msg)
            {
                Console.WriteLine(msg);
            }
        }

    }
}
