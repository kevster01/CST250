using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardModel
{
    public class Board
    {
        // the board is always square. Usually 8x8
        public int Size { get; set; }

        //2d array of Cell objects 
        public Cell[,] theGrid; 
       
        /// <summary>
        /// creates board constructorS
        /// </summary>
        /// <param name="s"></param>
        public Board(int s)
        {
            Size = s;
            // we must initiaize the array to avoid Null Exception errors
            theGrid = new Cell[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    theGrid[i,j] = new Cell(i,j);
                }
            }
        }

        /// <summary>
        /// Sets legal move and showcases option
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        private void SetLegalNextMove(int r, int c)
        {
            const int minRow = 0;
            int maxRow = theGrid.GetUpperBound(0);
            const int minColumn = 0;
            int maxColumn = theGrid.GetUpperBound(1);

            if (r < minRow || r > maxRow || c < minColumn || c > maxColumn)
            {
                // Silently Return
                return;
            }

            theGrid[r, c].LegalNextMove = true;
        }

        /// <summary>
        /// Produces action for movement of RookS
        /// </summary>
        /// <param name="cell"></param>
        private void createRookMoves(Cell cell)
        {
            // Vertical Upward
            for (int row = cell.RowNumber - 1; row >= 0; row--)
            {
                SetLegalNextMove(row, cell.ColumnNumber);
            }
            for (int row = cell.RowNumber + 1; row < theGrid.GetLength(0); row++)
            {
                SetLegalNextMove(row, cell.ColumnNumber);
            }
            for (int col = cell.ColumnNumber - 1; col >= 0; col--)
            {
                SetLegalNextMove(cell.RowNumber, col);
            }
            for (int col = cell.ColumnNumber + 1; col < theGrid.GetLength(1); col++)
            {
                SetLegalNextMove(cell.RowNumber, col);
            }
        }

        /// <summary>
        /// creates movement for Bishop
        /// </summary>
        /// <param name="cell"></param>
        private void createBishopMoves(Cell cell)
        {
            // Move diagonally up and left
            int row = cell.RowNumber - 1;
            int column = cell.ColumnNumber - 1;
            while (row >= 0 && column >= 0)
            {
                SetLegalNextMove(row, column);
                row--;
                column--;
            }

            // Move diagonally up and right
            row = cell.RowNumber - 1;
            column = cell.ColumnNumber + 1;
            while (row >= 0 && column < theGrid.GetLength(1))
            {
                SetLegalNextMove(row, column);
                row--;
                column++;
            }

            // Move diagonally down and left
            row = cell.RowNumber + 1;
            column = cell.ColumnNumber - 1;
            while (row < theGrid.GetLength(0) && column >= 0)
            {
                SetLegalNextMove(row, column);
                row++;
                column--;
            }

            // Move diagonally down and right
            row = cell.RowNumber + 1;
            column = cell.ColumnNumber + 1;
            while (row < theGrid.GetLength(0) && column < theGrid.GetLength(1))
            {
                SetLegalNextMove(row, column);
                row++;
                column++;
            }
        }

        /// <summary>
        /// Marks next legal movement
        /// </summary>
        /// <param name="currentCell"></param>
        /// <param name="ChessPiece"></param>
        public void MarkNextLegalMoves(Cell currentCell, string ChessPiece)
        {
               //step 1 - clear all legalMoves from previous turn. 
            for (int r = 0; r < Size; r++)
            {
                for(int c = 0; c < Size; c++) 
                {
                    theGrid[r, c].LegalNextMove = false;
                }
            }

            // step 2 - find all legal moves and mark the square
            switch (ChessPiece)
            {
                case "Knight":

                    SetLegalNextMove(currentCell.RowNumber - 2, currentCell.ColumnNumber - 1);
                    SetLegalNextMove(currentCell.RowNumber - 2, currentCell.ColumnNumber + 1);
                    SetLegalNextMove(currentCell.RowNumber - 1, currentCell.ColumnNumber + 2);
                    SetLegalNextMove(currentCell.RowNumber + 1, currentCell.ColumnNumber + 2);
                    SetLegalNextMove(currentCell.RowNumber + 2, currentCell.ColumnNumber + 1);
                    SetLegalNextMove(currentCell.RowNumber + 2, currentCell.ColumnNumber - 1);
                    SetLegalNextMove(currentCell.RowNumber + 1, currentCell.ColumnNumber - 2);
                    SetLegalNextMove(currentCell.RowNumber - 1, currentCell.ColumnNumber - 2);
                    break;

                case "King" :
                    SetLegalNextMove(currentCell.RowNumber - 1, currentCell.ColumnNumber);
                    SetLegalNextMove(currentCell.RowNumber - 1, currentCell.ColumnNumber - 1);
                    SetLegalNextMove(currentCell.RowNumber - 1, currentCell.ColumnNumber + 1);
                    SetLegalNextMove(currentCell.RowNumber, currentCell.ColumnNumber - 1);
                    SetLegalNextMove(currentCell.RowNumber, currentCell.ColumnNumber + 1);
                    SetLegalNextMove(currentCell.RowNumber + 1, currentCell.ColumnNumber - 1);
                    SetLegalNextMove(currentCell.RowNumber + 1, currentCell.ColumnNumber);
                    SetLegalNextMove(currentCell.RowNumber + 1, currentCell.ColumnNumber + 1);
                    break;

                case "Rook" :
                    createRookMoves(currentCell);
                    break;

                case "Bishop" :
                    createBishopMoves(currentCell);
                    break;

                case "Queen" :
                    createRookMoves(currentCell);
                    createBishopMoves(currentCell);

                    break;

                default : break;

            }


        }

    }
}
