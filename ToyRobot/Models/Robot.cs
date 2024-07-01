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


        /// <summary>
        /// Generates formatted string of Robot position.
        /// </summary>
        /// <returns></returns>
        public string Report()
        {
            if (Position == null) { return "NO POSITION TO REPORT."; }

            return $"{Position.X},{Position.Y},{Position.Direction}";
        }

        /// <summary>
        /// Returns robot icon based off the direction the robot is facing
        /// </summary>
        /// <returns></returns>
        public string GetRobotIcon()
        {
            if(Position == null || Position.Direction == null) { return "?"; }

            switch (Position.Direction)
            {
                case Direction.NORTH:
                    return "▲";
                case Direction.SOUTH:
                    return "▼";
                case Direction.EAST:
                    return "►";
                case Direction.WEST:
                    return "◄";
                default:
                    return "?";
            }
        }
    }
}
