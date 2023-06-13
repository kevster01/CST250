using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace M1_MineSweeper
{
    class easyModeBoard:Board
    {
        
        /// <summary>
        /// Creates a board for easy mode
        /// </summary>
        public easyModeBoard() : base()
        {
            Title = "Easy";
            Horizontal = 9;
            Vertical = 9;
            TwoDigitYAxis = false;
            TwoDigitXAxis = false;
            TotalMines = 10;
            CreateEmptyCellArray();
        }
    }
}
