using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace M1_MineSweeper
{
    class hardModeBoard : Board
    {
        /// <summary>
        /// creates a board for hard mode
        /// </summary>
        public hardModeBoard() : base()
        {
            Title = "Hard";
            Horizontal = 16;
            Vertical = 30;
            TwoDigitYAxis = true;
            TwoDigitXAxis = true;
            TotalMines = 99;
            CreateEmptyCellArray();
        }
    }
}
