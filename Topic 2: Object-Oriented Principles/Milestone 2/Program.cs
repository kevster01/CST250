using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace M1_MineSweeper
{
    class Program : playable
    {
        static void Main(string[] args)
        {
            Console.Title = "Console Minsweeper Game";
            bool run = true;
            while (run)
            {
                Board currentBoard = GetGameMode();
                PlayGame(currentBoard);
                if (!ContinueGame())
                {
                    run = false;
                }
            }
        }

        /// <summary>
        /// Gets the game mode selected by the user.
        /// </summary>
        /// <returns>The selected game board</returns>
        public static Board GetGameMode()
        {
            Console.WriteLine("Please select a game mode:");
            Console.WriteLine("1. Easy Mode");
            Console.WriteLine("2. Medium Mode");
            Console.WriteLine("3. Hard Mode");
            Console.WriteLine("4. Custom Mode");
            int menuOptionInput = validateConsole.GetIntegerInRange(1, 4);
            switch (menuOptionInput)
            {
                case 1:
                    Board easyBoard = new easyModeBoard();
                    return easyBoard;
                case 2:
                    Board mediumBoard = new mediumModeBoard();
                    return mediumBoard;
                case 3:
                    Board hardBoard = new hardModeBoard();
                    return hardBoard;
                default:
                    Console.Write("Horizontal size (5-30): ");
                    int customHorizontalInput = validateConsole.GetIntegerInRange(5, 30);
                    Console.Write("Vertical size (5-30): ");
                    int customVerticalInput = validateConsole.GetIntegerInRange(5, 30);
                    int customBoardArea = customHorizontalInput * customVerticalInput;
                    Console.WriteLine($"Amount of mines (1-{customBoardArea - 9}):");
                    int customMinesInput = validateConsole.GetIntegerInRange(1, customBoardArea - 9);
                    Board customBoard = new createCustomBoard(customHorizontalInput, customVerticalInput, customMinesInput);
                    return customBoard;
            }
        }

        /// <summary>
        /// Plays the MineSweeper game with the given board.
        /// </summary>
        /// <param name="currentBoard"></param>
        public static void PlayGame(Board currentBoard)
        {
            bool runGame = true;
            while (runGame)
            {
                Console.Clear();
                Console.WriteLine($"{currentBoard.Title} Mode - {currentBoard.TotalMines} mines");
                currentBoard.WriteBoard();
                if(currentBoard.State == Board.GameState.MineSelected)
                {
                    Console.WriteLine("Game over... You hit a Mine!");
                    return;
                }
                else if(currentBoard.State == Board.GameState.GameWon)
                {
                    Console.WriteLine("You won!");
                    return;
                }
                Console.WriteLine("Type a coordinate followed by S or F to select or flag");
                Console.WriteLine("For example: To select 1/3 you would enter '1/3 S' ");
                inputCoordinates coordinates = validateConsole.GetValidCoordinates(currentBoard.Vertical, currentBoard.Horizontal);
                int yCoord = currentBoard.Vertical - coordinates.Y;
                int xCoord = coordinates.X - 1;
                if(coordinates.Option == SelectOrFlag.S)
                {
                    currentBoard.FlagCell(yCoord, xCoord);
                }
            }
        }

        /// <summary>
        /// Method used to continue game if player decided to continue playing
        /// </summary>
        /// <returns></returns>
        public static bool ContinueGame()
        {
            Console.Write("Would you like to play again?(y/n): ");
            string input = validateConsole.GetValidString(new string[] { "y", "n" });
            if(input == "y")
            {
                Console.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Prints reposnses for user
        /// </summary>
        /// <param name="stringValue"></param>
        /// <param name="color"></param>
        public static void PrintColoredString(string stringValue, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(stringValue);
            Console.ResetColor();
        }

        /// <summary>
        /// The method PlayGame() is declared but not implemented. It throws a NotImplementedException, which is an exception 
        /// indicating that the method is declared but not implemented yet. 
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void PlayGame()
        {
            throw new NotImplementedException();
        }
    }
}
