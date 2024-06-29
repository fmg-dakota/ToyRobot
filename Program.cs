using ToyRobot.Models;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            const int TABLETOP_WIDTH = 5;
            const int TABLETOP_HEIGHT = 5;

            Robot robot = new Robot();
            Tabletop tabletop = new Tabletop(TABLETOP_WIDTH, TABLETOP_HEIGHT);



        }
    }
}