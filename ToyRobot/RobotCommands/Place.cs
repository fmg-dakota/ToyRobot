using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Models;
using ToyRobot.RobotCommands;

namespace ToyRobot.RobotCommands
{
    internal class Place : IRobotCommand
    {
        private Robot _robot;
        private Tabletop _tabletop;
        private Position _position;

        public Place(Tabletop tabletop, Robot robot, Position position)
        {
            this._tabletop = tabletop;
            this._robot = robot;
            this._position = position;
        }

        /// <summary>
        /// Implementation of execute() IRobotCommand interface.
        /// If proposed position is valid, the robots position is updated.
        /// </summary>
        public void execute()
        {
            if (_tabletop.IsValidPosition(_position))
            {
                this._robot.Position = _position;
            }
        }
    }
}
