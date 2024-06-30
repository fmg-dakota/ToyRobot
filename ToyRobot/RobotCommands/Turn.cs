using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Models;
using ToyRobot.RobotCommands;

namespace ToyRobot.RobotCommands
{
    internal class Turn : IRobotCommand
    {
        private Robot _robot;
        private string _leftRight;

        // This might not be entirely readable... but not sure if my first attempt of a switch with nested if statements is worse.
        //    I guess this could be simplified if I made turn left and turn right into their own commands but seemed like it would be
        //    repetetive. Also not entirely sure why I had to set the outer dictionary Direction key as nullable, I think because Position.Direction is nullable?
        private Dictionary<Direction?, Dictionary<string, Direction>> _directionMap = new()
        {
            { Direction.NORTH, new Dictionary<string, Direction> { { "RIGHT", Direction.EAST }, { "LEFT", Direction.WEST } } },
            { Direction.EAST, new Dictionary<string, Direction> { { "RIGHT", Direction.SOUTH }, { "LEFT", Direction.NORTH } } },
            { Direction.SOUTH, new Dictionary<string, Direction> { { "RIGHT", Direction.WEST }, { "LEFT", Direction.EAST } } },
            { Direction.WEST, new Dictionary<string, Direction> { { "RIGHT", Direction.NORTH }, { "LEFT", Direction.SOUTH } } }
        };

        public Turn(Robot robot, string leftRight)
        {
            this._robot = robot;
            this._leftRight = leftRight;
        }

        public void execute()
        {
            if (_robot == null || _robot.Position == null || _robot.Position.Direction == null) { return; }

            _robot.Position.Direction = _directionMap[_robot.Position.Direction][_leftRight];
        }
    }
}
