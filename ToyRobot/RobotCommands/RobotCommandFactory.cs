﻿using System;
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

        // Regex to match the place cmd, eg. PLACE 1,1,NORTH
        private string _placeRegex = @"PLACE\s(\d+),(\d+),(NORTH|SOUTH|EAST|WEST)$";

        public RobotCommandFactory(Tabletop tabletop, Robot robot, UI ui)
        {
            _tabletop = tabletop;
            _robot = robot;
            _ui = ui;
        }

        /// <summary>
        /// Returns the relevant command object depending on the input command.
        /// </summary>
        /// <param name="cmd">Input command</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Exception for invalid command input.</exception>
        public IRobotCommand? BuildCommand(string cmd)
        {
            // This is only a basic implemntation of the factory pattern for a basic app.
            // TODO: There's probably a more graceful way to handle the different cases in a switch
            //    statement...
            if (cmd.Contains("PLACE"))
            {
                try
                {
                    Position newPos = ParsePlaceCmd(cmd);
                    return new Place(_tabletop, _robot, newPos);
                }
                catch (ArgumentException e)
                {
                    throw new ArgumentException($"PLACE command: {e.Message}");
                }
            }
            else if (cmd == "MOVE")
            {
                return new Move(_tabletop, _robot);
            }
            else if (cmd == "LEFT")
            {
                return new TurnLeft(_robot);
            }
            else if (cmd == "RIGHT")
            {
                return new TurnRight(_robot);
            }
            else if (cmd == "REPORT")
            {
                return new Report(_tabletop, _robot, _ui);
            }
            else
            {
                throw new ArgumentException("Invalid command input."); ;
            }
        }

        /// <summary>
        /// Parses the PLACE 1,1,NORTH command and returns a Position based off it.
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns>Position object based off the PLACE values</returns>
        /// <exception cref="ArgumentException">Invalid PLACE format.</exception>
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
    }
}
