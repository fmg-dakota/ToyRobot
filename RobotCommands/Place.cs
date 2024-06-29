using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Models;
using ToyRobot.RobotCommands;

namespace ToyRobot.Commands
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

        public void execute()
        {
            if (_tabletop.IsValidPosition(_position))
            {
                this._robot.Position = _position;
            }
        }
    }
}
