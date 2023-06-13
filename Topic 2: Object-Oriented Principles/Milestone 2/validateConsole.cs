using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;



namespace M1_MineSweeper
{
    class validateConsole
    {
        // Gets a valid string input from the user, restricted to a specified set of options
        public static string GetValidString(string [] options)
        {
            string input;
            string listOfOptions = string.Join(",", options);
            while (true)
            {
                input = Console.ReadLine().Trim().ToLower();
                foreach(string item in options)
                {
                    if(input == item)
                    {
                        return input;
                    }
                }
                Program.PrintColoredString($"Input must be either of the following: [{listOfOptions}]. Try again.", ConsoleColor.DarkRed);

            }
        }

        // Gets a valid integer input from the user
        public static int GetValidInteger()
        {
            int input;
            while(!int.TryParse(Console.ReadLine(), out input))
            {
                Program.PrintColoredString("Invalid input. Please try again by entering an Integer.", ConsoleColor.DarkRed);
            }
            return input;
        }

        // Gets a valid integer input from the user within a specified range
        public static int GetIntegerInRange(int min, int max)
        {
            int input = GetValidInteger();
            while(input < min || input > max)
            {
                Program.PrintColoredString($"Input is not between {min} and {max}. Please try again. ", ConsoleColor.DarkRed);
                input = GetValidInteger();
            }
            return input;
        }

        // Gets valid coordinates input from the user within the specified range
        public static inputCoordinates GetValidCoordinates(int vertical, int horizontal)
        {
            while (true)
            {
                string input = Console.ReadLine().Trim().ToLower();
                string[] values;
                // check that user input is 0-30, either \/, 0-30, space and either s or f 
                if ( !Regex.IsMatch(input, @"([0-9]|[1-2][0-9]|30)\/([0-9]|[1-2][0-9]|30)\s[sf]"))
                {
                    Program.PrintColoredString("Invalid input. Enter an int between 0-30. Please try again", ConsoleColor.DarkRed);
                    continue;
                }
                values = input.Split(new char[] { '/', ' ' });
                if(!int.TryParse(values[0], out int x))
                {
                    Program.PrintColoredString("Invalid x input; please try again", ConsoleColor.DarkRed);
                    continue;
                }
                if(!int.TryParse(values[1],out int y))
                {
                    Program.PrintColoredString("Invalid y input; please try again", ConsoleColor.DarkRed);
                    continue;
                }
                if(x<1 || x > horizontal)
                {
                    Program.PrintColoredString($"X is not between 1 and {horizontal}", ConsoleColor.DarkRed);
                    continue;
                }
                if(y<1 || y > vertical)
                {
                    Program.PrintColoredString($"Y is not between 1 and {vertical}", ConsoleColor.DarkRed);
                    continue;
                }
                if(!Enum.TryParse(values[2].ToUpper(),out SelectOrFlag option))
                {
                    Program.PrintColoredString($"Action is not S or F. Please try again", ConsoleColor.DarkRed);
                    continue;
                }
                return new inputCoordinates(y, x, option);
            }
        }
    }
}
