using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ToyRobot.Models;

namespace ToyRobot.RobotCommands
{
    internal class RobotCommandFactory
    {
        private Tabletop _tabletop;
        private Robot _robot;
        private UI _ui;

        private string _placeRegex = @"PLACE\s(\d+),(\d+),(NORTH|SOUTH|EAST|WEST)$";

        public RobotCommandFactory(Tabletop tabletop, Robot robot, UI ui)
        {
            _tabletop = tabletop;
            _robot = robot;
            _ui = ui;
        }

        public IRobotCommand? BuildCommand(string cmd)
        {
            if (!IsValidCommand(cmd)) { throw new ArgumentException("Invalid command input."); }

            if (cmd.Contains("PLACE"))
            {
                Position newPos = ParsePlaceCmd(cmd);
                return new Place(_tabletop, _robot, newPos);
            }
            else if (cmd == "MOVE")
            {
                return new Move(_tabletop, _robot);
            }
            else if (cmd == "LEFT" || cmd == "RIGHT")
            {
                return new Turn(_robot, cmd);
            }
            else if (cmd == "REPORT")
            {
                return new Report(_tabletop, _robot, _ui);
            }
            else
            {
                return null;
            }
        }

        private Position ParsePlaceCmd(string cmd)
        {

            Match match = Regex.Match(cmd, _placeRegex);

            if (!match.Success)
            {
                throw new ArgumentException("Invalid command format");
            }

            // These try parses should always work if the regex successfully matches but just
            //   to be safe I've added some exceptions.
            if (!int.TryParse(match.Groups[1].Value, out int x))
            {
                throw new ArgumentException("Invalid value for X coordinate");
            }

            if (!int.TryParse(match.Groups[2].Value, out int y))
            {
                throw new ArgumentException("Invalid value for Y coordinate");
            }

            if (!Enum.TryParse(match.Groups[3].Value, out Direction direction))
            {
                throw new ArgumentException("Invalid value for direction");
            }

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
