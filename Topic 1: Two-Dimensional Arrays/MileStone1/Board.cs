using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperConsoleApp
{
    public class Board
    {
        private Cell[,] gameBoard;
        private int boardSize;
        private double difficulty;
        private Random random = new Random();


        /// <summary>
        /// Constructor 
        /// </summary>
        public Board()
        {
            DetermineBoardSize();
            gameBoard = new Cell[boardSize, boardSize];
            difficulty = 0.5;
        }

        /// <summary>
        /// Identifies difficulty of Minesweeper
        /// </summary>
        public double Difficulty
        {
            get { return difficulty; }
            set { difficulty = value; }
        }

        /// <summary>
        /// Method to determine board size
        /// </summary>
        private void DetermineBoardSize()
        {
            boardSize = 0;
            while (boardSize < 8 || boardSize > 25)
            {
                Console.WriteLine("Enter the board size you would like to generate. (Between 8 and 25)");
                boardSize = Convert.ToInt32(Console.ReadLine());
                if (boardSize < 1 || boardSize > 25)
                    Console.WriteLine("Invalid board size, please enter a number between 8 and 25");
            }
            Console.WriteLine("Thank you, your board will be displayed shortly.");
        }
        //Method to create each Cell and fill the gameBoard
        public void PopulateBoard()
        {
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    Cell gameCell = new Cell(i, j);
                    gameCell.Live = SetUpLiveNeighbors();
                    if (gameCell.Live == true)
                        gameCell.LiveNeighbors = 9;
                    gameBoard[i, j] = gameCell;
                }
            }
            calculateLiveNeighbors();
        }

        //Establishes and checks for difficulty
        public bool SetUpLiveNeighbors() => random.NextDouble() < difficulty;



        //Method to determine number of live neighbors
        private void calculateLiveNeighbors()
        {
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    int x = 0;

                    x += checkingForNeighbors(i - 1, j - 1);
                    x += checkingForNeighbors(i - 1, j);
                    x += checkingForNeighbors(i - 1, j + 1);
                    x += checkingForNeighbors(i, j - 1);
                    x += checkingForNeighbors(i, j + 1);
                    x += checkingForNeighbors(i + 1, j - 1);
                    x += checkingForNeighbors(i + 1, j);
                    x += checkingForNeighbors(i + 1, j + 1);

                    gameBoard[i, j].LiveNeighbors = x;
                }
            }
        }

        /**
         * Checks for neighbors
         */
        private int checkingForNeighbors(int x, int y)
        {
            if (x > -1 && y > -1)
            {
                if (x < boardSize && y < boardSize)
                {
                    if (gameBoard[x, y].Live == true)
                        return 1;
                }
            }
            return 0;
        }
        //Method to print board to console
        public void DisplayGameBoard()
        {
            for (int i = 0; i < gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    if (gameBoard[i, j].Live)
                        Console.Write("* ");
                    else
                        Console.Write("{0} ", gameBoard[i, j].LiveNeighbors);
                }
                Console.Write("\n");
            }
            Console.ReadLine();
        }
    }
}
