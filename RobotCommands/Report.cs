using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Models;
using ToyRobot.RobotCommands;

namespace ToyRobot.Commands
{
    internal class Report : IRobotCommand
    {
        private Robot _robot;

        public Report(Robot robot)
        {
            this._robot = robot;
        }

        public void execute()
        {
            Console.WriteLine(_robot.Report());
        }
    }
}
