using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperConsoleApp
{
    public class Cell
    {
        /// <summary>
        /// Gets/ Sets for Row, Column, LiveNeighbors, Visited, and Live
        /// </summary>
        public int Row { get; set; }
        public int Column { get; set; }
        public int LiveNeighbors { get; set; }
        public bool Visited { get; set; }
        public bool Live { get; set; }

        /**
         * Creates a physical cell for minesweeper
         */
        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
            Visited = false;
            Live = false;
            LiveNeighbors = 0;
        }
    }
}
