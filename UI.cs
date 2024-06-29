using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ToyRobot.Models;

namespace ToyRobot
{
    internal class UI
    {
        private string _placeRegex = @"PLACE\s(\d+),(\d+),(NORTH|SOUTH|EAST|WEST)$";

        public UI() { }

        public void PrintMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        public string GetCommandInput(string prompt)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (input == null || !IsValidCommand(input)) { return ""; }

            return input;
        }

        public void PrintSimulationStart(int tabletopWidth, int tabletopHeight)
        {
            Console.WriteLine($"---------TOY ROBOT SIMULATOR---------");
            Console.WriteLine($"Tabletop dimensions: {tabletopWidth} x {tabletopHeight}");
            Console.WriteLine("Commands:");
            Console.WriteLine("\tPLACE X, Y, (NORTH|SOUTH|EAST|WEST)");
            Console.WriteLine("\tMOVE");
            Console.WriteLine("\tLEFT");
            Console.WriteLine("\tRIGHT");
            Console.WriteLine("\tREPORT");
            Console.WriteLine("\tQUIT\n");
        }

        // !!! - Potentially a better place to put this place cmd parsing maybe...
        public Position ParsePlaceCmd(string cmd)
        {
            Match match = Regex.Match(cmd, _placeRegex);
            int x = int.Parse(match.Groups[1].Value);
            int y = int.Parse(match.Groups[2].Value);
            Direction direction = (Direction)Enum.Parse(typeof(Direction), match.Groups[3].Value);
            return new Position(x, y, direction);
        }

        private bool IsValidCommand(string cmd)
        {
            if (string.IsNullOrEmpty(cmd)) return false;

            string[] VALID_COMMANDS_REGEX =
            {
                _placeRegex,
                @"MOVE$",
                @"LEFT$",
                @"RIGHT$",
                @"REPORT$",
                @"QUIT$"
            };

            foreach (string cmdRegex in VALID_COMMANDS_REGEX)
            {
                if (Regex.IsMatch(cmd, cmdRegex))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
