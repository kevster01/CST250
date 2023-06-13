using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace M1_MineSweeper
{
    class createCustomBoard : Board
    {
        /// <summary>
        /// 
        // Initializes a new instance of the
        // CustomBoard class with the specified dimensions and mine count
        // Inherits from the base class (assuming
        // there is a base class that this class extends)
        /// </summary>
        /// <param name="horizontal"></param>
        /// <param name="vertical"></param>
        /// <param name="mines"></param>
        public createCustomBoard(int horizontal, int vertical, int mines): base()
        {
            Title = " Custom ";
            Horizontal = horizontal;
            Vertical = vertical;
            TwoDigitXAxis = Horizontal > 9 ? true : false;
            TwoDigitYAxis = Vertical > 9 ? true : false;
            TotalMines = mines;
            CreateEmptyCellArray();
        }
    }
}
