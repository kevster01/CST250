using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace M1_MineSweeper
{
     abstract class Board 
    {
        private Cell[,] cellArray;
        private string title;
        private int horizontal;
        private int vertical;
        private int totalMines;
        private bool twoDigitYAxis;
        private bool twoDigitXAxis;
        private GameState state;
        public Board()
        {
            state = GameState.BlankGameBoard;
        }

        /// <summary>
        ///  This method is responsible for displaying the game board on the console. 
        ///  It iterates over the cells of the board and prints different characters based on their states 
        ///  (flagged, mine, selected, or surrounding mines value). It also checks if the game has been won.
        /// </summary>
        public void WriteBoard()
        {
            int selectableCells = Horizontal * Vertical;
            for(int y = 0; y < Vertical; y++)
                //checks through y values from top to bottom
            {
                WriteYCoordinate(y);
                for(int x=0; x<Horizontal; x++)
                    //checks through x values from left to right
                {
                    Cell cell = CellArray[y, x];
                    if (cell.IsFlagged)
                    {
                        Program.PrintColoredString("F", ConsoleColor.Green);
                    }
                    else if (!cell.IsMine)
                    {
                        Program.PrintColoredString("#", ConsoleColor.DarkGray);
                    }else if (cell.IsMine)
                    {
                        Program.PrintColoredString("X", ConsoleColor.Red);
                        State = GameState.MineSelected;
                    }
                    else
                    {
                        WriteColoredSurroundingMinesValue(cell.SurroundingMinesValue);
                        selectableCells--;
                    }
                    if (twoDigitXAxis)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            WriteXCoordinates();
            if(selectableCells == TotalMines && State != GameState.MineSelected)
                //checks if game has been won
            {
                State = GameState.GameWon;
            }
        }

        /// <summary>
        /// This method is called when a cell is selected by the player. It sets the selected cell's IsSelected property 
        /// to true and checks the game state. If it's the first selection, it generates mines and updates the game state. 
        /// If the selected cell has no surrounding mines, it reveals the neighboring cells recursively
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        public void SelectCell(int y, int x)
        {
            Cell selectedCell = CellArray[y, x];
            if(selectedCell.IsSelected || selectedCell.IsFlagged)
            {
                return;
            }
            selectedCell.IsSelected = true;
            if(State == GameState.BlankGameBoard)
            {
                GenerateMines(y, x);
                State = GameState.GameInPregress;
            }
            if(selectedCell.SurroundingMinesValue == 0)
            {
                RevealAroundConnectingZeros(y, x);
            }
        }

        /// <summary>
        /// This method is used to toggle the flagged state of a cell. 
        /// It checks if the cell is already selected and, if not, it toggles the 
        /// IsFlagged property of the cell.
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        public void FlagCell(int y, int x)
        {
            Cell flaggedCell = CellArray[y, x];
            if (flaggedCell.IsSelected)
            {
                return;
            }
            flaggedCell.IsFlagged = !flaggedCell.IsFlagged;
        }

        /// <summary>
        /// This is a private recursive method that reveals cells around the selected cell when there are connecting zeros. 
        /// It sets the selected state for each neighboring cell and continues recursively for cells with no surrounding mines.
        /// </summary>
        /// <param name="yInput"></param>
        /// <param name="xInput"></param>
        private void RevealAroundConnectingZeros(int yInput, int xInput)
        {
            CellArray[yInput, xInput].SurroundingMinesChecked = true;
            for(int y = yInput -1; y <= yInput +1; y++)
            {
                if(y<0 || y >= Vertical)
                {
                    continue;
                }
                for( int x = xInput -1; x<= xInput+1; x++)
                {
                    if(x<0 || x >= Horizontal)
                    {
                        continue;
                    }
                    CellArray[y, x].IsSelected = true;
                    if(CellArray[y,x].SurroundingMinesValue == 0 && !CellArray[y, x].SurroundingMinesChecked)
                    {
                        RevealAroundConnectingZeros(y, x);
                    }
                }
            }
        }

        /// <summary>
        /// This method is responsible for generating mines on the board. 
        /// It first blacklists the cells around the initially selected cell to ensure the player does not
        /// hit a mine on the first move. Then it uses a random number generator to place the specified number 
        /// of mines on random cells that are not blacklisted, already mines, or already selected. 
        /// Finally, it calls GenerateSurroundMinesValues() to calculate the surrounding mines values for each cell.
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        private void GenerateMines(int y, int x)
        {
            BlacklistSurroundingCells(y, x);
            Random rnd = new Random();
            for(int i = 0; i < TotalMines; i++)
            {
                int yRndValue = rnd.Next(Vertical);
                int xRndValue = rnd.Next(Horizontal);
                Cell randomCell = CellArray[xRndValue, xRndValue];
                if(randomCell.IsMineBlacklisted || randomCell.IsMine || randomCell.IsSelected)
                {
                    i--;
                }
                else
                {
                    randomCell.IsMine = true;
                }
            }
            GenerateSurroundMinesValues();
        }

        /// <summary>
        ///  This method creates an empty 2D array of cells based on the provided vertical and horizontal dimensions.
        ///  It initializes each cell in the array as a new instance of the Cell class.
        /// </summary>
        protected void CreateEmptyCellArray()
        {
            CellArray = new Cell[Vertical, Horizontal];
            for(int y = 0; y < Vertical; y++)
            {
                for(int x =0; x< Horizontal; x++)
                {
                    CellArray[y, x] = new Cell();
                }
            }
        }

        /// <summary>
        /// This method blacklists the cells around a given cell position. 
        /// It sets the IsMineBlacklisted property to true for each surrounding cell.
        /// </summary>
        /// <param name="yInput"></param>
        /// <param name="xInput"></param>
        private void BlacklistSurroundingCells(int yInput, int xInput)
        {
            for(int y= yInput-1; y <= yInput + 1; y++)
            {
                if(y<0 || y>= Vertical)
                {
                    continue;
                }
                for(int x = xInput -1; x <= xInput+1; x++)
                {
                    if(x<0 || x> Horizontal)
                    {
                        continue;
                    }
                    CellArray[y, x].IsMineBlacklisted = true;
                }
            }
        }

        /// <summary>
        /// This method calculates the surrounding mines value for each cell in the board. 
        /// It iterates over each cell and counts the number of mines in the neighboring cells.
        /// </summary>
        private void GenerateSurroundMinesValues()
        {
            for(int y = 0; y < Vertical; y++)
            {
                for(int x=0; x < Horizontal; x++)
                {
                    CellArray[y, x].SurroundingMinesValue = CountSurroundingMines(y, x);
                }
            }
        }
        /// <summary>
        /// This method counts the number of mines in the surrounding cells of a given cell position.
        /// It iterates over the neighboring cells and increments a counter when a mine is found.
        /// </summary>
        /// <param name="yInput"></param>
        /// <param name="xInput"></param>
        /// <returns></returns>
        private int CountSurroundingMines(int yInput, int xInput)
        {
            int surroundingMinesValue = 0;
            for(int y = yInput -1; y<=yInput+1; y++)
            {
                if(y<0 || y >= Vertical)
                {
                    continue;
                }
                for(int x = xInput - 1; x <= xInput + 1; x++)
                {
                    if(x<0 || x>=Horizontal || !CellArray[y, x].IsMine)
                    {
                        continue;
                    }
                    surroundingMinesValue++;
                }
            }
            return surroundingMinesValue;
        }

        /// <summary>
        /// This method writes the y-coordinate of the game board on the console. 
        /// It prints the y-value in reverse order and adds a leading space if the game board has a two-digit y-axis.
        /// </summary>
        /// <param name="y"></param>
        private void WriteYCoordinate(int y)
        {
            int yValue = Vertical - y;
            Console.WriteLine(yValue + " ");
            if(twoDigitYAxis && yValue <= 9)
            {
                Console.Write(" ");
            }
        }

        /// <summary>
        ///  This method writes the x-coordinates of the game board on the console.
        ///  It iterates over the x-axis and prints the numbers, adding a leading space if the game board has a two-digit x-axis.
        /// </summary>
        private void WriteXCoordinates()
        {
            Console.Write(" ");
            if (twoDigitYAxis)
                Console.Write(" ");
            for(int i =0; i< Horizontal; i++)
            {
                Console.Write(i + 1 + " ");
                if (twoDigitXAxis && i + 1 < 10)
                    Console.Write(" ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// This method writes the surrounding mines value on the console with corresponding colors based on the number.
        /// It uses the Program.PrintColoredString method to print the number with the appropriate console color.
        /// </summary>
        /// <param name="number"></param>
        private void WriteColoredSurroundingMinesValue(int number)
        {
            switch (number)
            {
                case 0:
                    Console.Write(" ");
                    break;
                case 1:
                    Program.PrintColoredString("1", ConsoleColor.Blue);
                    break;
                case 2:
                    Program.PrintColoredString("2", ConsoleColor.Green);
                    break;
                case 3:
                    Program.PrintColoredString("3", ConsoleColor.Red);
                    break;
                case 4:
                    Program.PrintColoredString("4", ConsoleColor.DarkBlue);
                    break;
                case 5:
                    Program.PrintColoredString("5", ConsoleColor.DarkRed);
                    break;
                case 6:
                    Program.PrintColoredString("6", ConsoleColor.DarkCyan);
                    break;
                case 7:
                    Program.PrintColoredString("7", ConsoleColor.Black);
                    break;
                case 8:
                    Program.PrintColoredString("8", ConsoleColor.DarkGray);
                    break;
                default:
                    break;
            }
        }
        public enum GameState
        {
            BlankGameBoard, 
            GameInPregress,
            MineSelected,
            GameWon
        }
        /// <summary>
        /// The following methods are use to establish the elements of the game
        /// </summary>
        public Cell[,] CellArray { get => cellArray; set => cellArray = value; }
        public string Title { get => title; set => title = value; }
        public int Horizontal { get => horizontal; set => horizontal = value; }
        public int Vertical { get => vertical; set => vertical = value; }
        public int TotalMines { get => totalMines; set => totalMines = value; }
        protected bool TwoDigitYAxis { get => twoDigitYAxis; set => twoDigitYAxis = value; }
        protected bool TwoDigitXAxis { get => twoDigitXAxis; set => twoDigitXAxis = value; }
        public GameState State { get => state; set => state = value; }
    }
}
