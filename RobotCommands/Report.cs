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
        private UI _ui;

        public Report(Robot robot, UI ui)
        {
            this._robot = robot;
            this._ui = ui;
        }

        public void execute()
        {
            _ui.PrintMessage(_robot.Report());
        }
    }
}
