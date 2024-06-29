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
        private Tabletop _tabletop;
        private Robot _robot;
        private UI _ui;

        public Report(Tabletop tabletop, Robot robot, UI ui)
        {
            this._tabletop = tabletop;
            this._robot = robot;
            this._ui = ui;
        }

        private string GenerateTabletopOutput()
        {
            if (_robot.Position == null) { return ""; }

            string tabletopString = "";
            for (int i = _tabletop.height - 1; i >= 0; i--)
            {
                for (int j = 0; j < _tabletop.width; j++)
                {
                    if (i == _robot.Position.Y && j == _robot.Position.X)
                    {
                        tabletopString += $"[{_robot.GetRobotIcon()}]";
                    }
                    else
                    {
                        tabletopString += "[ ]";
                    }
                }
                tabletopString += "\n";
            }
            return tabletopString;

        }


        public void execute()
        {
            _ui.PrintMessage(_robot.Report());
            _ui.PrintMessage(GenerateTabletopOutput());
        }
    }
}
