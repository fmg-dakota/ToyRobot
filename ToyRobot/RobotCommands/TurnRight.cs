﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobot.Models;

namespace ToyRobot.RobotCommands
{
    internal class TurnRight : IRobotCommand
    {
        private Robot _robot;

        public TurnRight(Robot robot)
        {
            this._robot = robot;
        }

        public void execute()
        {
            if (_robot == null || _robot.Position == null || _robot.Position.Direction == null) { return; }

            switch (_robot.Position.Direction)
            {
                case Direction.NORTH:
                    _robot.Position.Direction = Direction.EAST;
                    break;
                case Direction.SOUTH:
                    _robot.Position.Direction = Direction.WEST;
                    break;
                case Direction.EAST:
                    _robot.Position.Direction = Direction.SOUTH;
                    break;
                case Direction.WEST:
                    _robot.Position.Direction = Direction.NORTH;
                    break;
            }
        }
    }
}