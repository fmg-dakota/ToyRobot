using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Models;
using ToyRobot.RobotCommands;

namespace ToyRobot.RobotCommands
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

        /// <summary>
        /// Generates a pretty string representation of the state of the tabletop and robot.
        /// </summary>
        /// <returns>String representation of tabletop and robot</returns>
        private string GenerateTabletopOutput()
        {
            if (_robot.Position == null) { return ""; }

            string tabletopString = "";

            // x decrements here because of the layout of the simulation.
            //    0,0 is the origin in the SOUTH WEST corner so we want to
            //    start drawing from the bottom.
            for (int y = _tabletop.height - 1; y >= 0; y--)
            {
                for (int x = 0; x < _tabletop.width; x++)
                {
                    if (y == _robot.Position.Y && x == _robot.Position.X)
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

        /// <summary>
        /// Implementation of execute() IRobotCommand interface.
        /// </summary>
        public void execute()
        {
            _ui.PrintMessage(_robot.Report());
            _ui.PrintMessage(GenerateTabletopOutput());
        }
    }
}
