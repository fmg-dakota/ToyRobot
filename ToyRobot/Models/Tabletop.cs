namespace ToyRobot.Models
{
    internal class Tabletop
    {
        public int width { get; set; }
        public int height { get; set; }

        public Tabletop(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public bool IsValidPosition(Position position)
        {
            if (position == null) { return false; }
            if (position.X >= width || position.Y >= height || position.X < 0 || position.Y < 0) { return false; }

            return true;
        }
    }
}
