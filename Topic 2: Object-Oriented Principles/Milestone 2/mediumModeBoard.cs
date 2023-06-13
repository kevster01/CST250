using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace M1_MineSweeper
{
    class mediumModeBoard : Board
    {
        /// <summary>
        /// Creates board for medium mode
        /// </summary>
        public mediumModeBoard() : base()
        {
            Title = "Medium";
            Horizontal = 16;
            Vertical = 16;
            TwoDigitYAxis = true;
            TwoDigitXAxis = true;
            TotalMines = 40;
            CreateEmptyCellArray();
        }
    }
}
