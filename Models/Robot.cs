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
            return $"{Position.X},{Position.Y},{Position.Direction}";
        }
    }
}
