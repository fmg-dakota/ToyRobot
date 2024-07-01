using ToyRobot.Models;

namespace ToyRobot.RobotCommands
{
    /// <summary>
    /// Command that moves Robot +1 place in whatever direction it
    /// is facing, as long as the new location is valid.
    /// </summary>
    internal class Move : IRobotCommand
    {
        private Robot _robot;
        private Tabletop _tabletop;

        public Move(Tabletop tabletop, Robot robot)
        {
            this._robot = robot;
            this._tabletop = tabletop;
        }

        /// <summary>
        /// Implementation of execute() IRobotCommand interface.
        /// If proposed move is valid, the robots position is updated.
        /// </summary>
        public void execute()
        {
            if (_robot == null || _robot.Position == null) { return; }
            if (_robot.Position.X == null || _robot.Position.Y == null || _robot.Position.Direction == null) { return; }

            Position? newPos = null;

            switch (this._robot.Position.Direction)
            {
                case (Direction.NORTH):
                    newPos = new Position(_robot.Position.X, _robot.Position.Y + 1, _robot.Position.Direction);
                    break;
                case (Direction.SOUTH):
                    newPos = new Position(_robot.Position.X, _robot.Position.Y - 1, _robot.Position.Direction);
                    break;
                case (Direction.EAST):
                    newPos = new Position(_robot.Position.X + 1, _robot.Position.Y, _robot.Position.Direction);
                    break;
                case (Direction.WEST):
                    newPos = new Position(_robot.Position.X - 1, _robot.Position.Y, _robot.Position.Direction);
                    break;
                default:
                    break;
            }

            if (newPos == null) { return; }

            if (_tabletop.IsValidPosition(newPos))
            {
                _robot.Position = newPos;
            }
        }
    }
}
