using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobot.Models
{
    internal class Robot
    {
        public Position? Position { get; set; }

        public Robot()
        {
            Position = null;
        }

        public Robot(Position position)
        {
            Position = position;
        }

        public string Report()
        {
            if (Position == null) { return "MUST PLACE ROBOT FIRST."; }

            return $"{Position.X},{Position.Y},{Position.Direction}";
        }

        public string GetRobotIcon()
        {
            switch (Position.Direction)
            {
                case Direction.NORTH:
                    return "▲";
                case Direction.SOUTH:
                    return "▼";
                case Direction.WEST:
                    return "◄";
                case Direction.EAST:
                    return "►";
                default:
                    return "?";
            }
        }
    }
}
