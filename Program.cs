﻿using ToyRobot.Models;
using ToyRobot.RobotCommands;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            const int TABLETOP_WIDTH = 5;
            const int TABLETOP_HEIGHT = 5;

            UI ui = new UI();
            Robot robot = new Robot();
            Tabletop tabletop = new Tabletop(TABLETOP_WIDTH, TABLETOP_HEIGHT);
            
            RobotCommandFactory robotCommandFactory = new RobotCommandFactory(tabletop, robot, ui);

            ui.PrintSimulationStart(TABLETOP_WIDTH, TABLETOP_HEIGHT);

            string cmd = "";
            while (cmd != "QUIT")
            {
                cmd = ui.GetCommandInput("ENTER COMMAND: ");

                try
                {
                    robotCommandFactory.BuildCommand(cmd).execute();
                }
                catch (ArgumentException ex)
                {
                    // Do nothing for invalid command inputs :)
                }
            }
        }
    }
}