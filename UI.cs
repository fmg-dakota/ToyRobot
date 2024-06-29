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
        

        public UI() { }

        public void PrintMessage(string msg)
        {
            Console.WriteLine(msg);
        }

        public string GetCommandInput(string prompt)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            //if (input == null || !IsValidCommand(input)) { return ""; }
            if(input == null) { return ""; }

            return input;
        }

        public void PrintSimulationStart(int tabletopWidth, int tabletopHeight)
        {
            Console.WriteLine($"---------TOY ROBOT SIMULATOR---------");
            Console.WriteLine($"Tabletop dimensions: {tabletopWidth} x {tabletopHeight}");
            Console.WriteLine("Commands:");
            Console.WriteLine("\tPLACE X,Y,(NORTH|SOUTH|EAST|WEST)");
            Console.WriteLine("\tMOVE");
            Console.WriteLine("\tLEFT");
            Console.WriteLine("\tRIGHT");
            Console.WriteLine("\tREPORT");
            Console.WriteLine("\tQUIT\n");
        }
    }
}
