using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace M1_MineSweeper
{
    class inputCoordinates
    {
        private int y;
        private int x;
        private SelectOrFlag option;

        /// <summary>
        /// Method created for user to input coordinates 
        /// and established the cells as selected or flaggeds
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        /// <param name="option"></param>
        public inputCoordinates(int y, int x, SelectOrFlag option)
        {
            this.y = y;
            this.x = x;
            this.option = option;
        }
        public int Y { get => y; set => y = value; }
        public int X { get => x; set => x = value; }
        public SelectOrFlag Option { get => option; set => option = value; }
    }
    public enum SelectOrFlag
    {
        F,
        S
    };
}
