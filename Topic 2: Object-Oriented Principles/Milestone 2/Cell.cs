using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace M1_MineSweeper
{
    public class Cell
    {
        private bool isMine;
        private bool isSelected;
        private bool isFlagged;
        private bool isMineBlacklisted;
        private bool surroundingMinesChecked;
        private int surroundingMinesValue;
        
        /// <summary>
        /// Creating a cell constructor
        /// </summary>
        public Cell()
        {
            SurroundingMinesValue = 0;
            isMine = false;
            isSelected = false;
            isFlagged = false;
            isMineBlacklisted = false;
            surroundingMinesChecked = false;
        }

        // Gets or sets a value indicating whether the cell contains a mine
        public bool IsMine { get => isMine; set => isMine = value; }
        
        // Gets or sets a value indicating whether the cell is selected
        public bool IsSelected { get => isSelected; set => isSelected = value; }

        // Gets or sets a value indicating whether the cell is flagged
        public bool IsFlagged { get => isFlagged; set => isFlagged = value; }
        
        // Gets or sets a value indicating whether the cell is blacklisted for mine placement
        public bool IsMineBlacklisted { get => isMineBlacklisted; set => isMineBlacklisted = value; }
    
        // Gets or sets the number of surrounding mines for the cell
        public int SurroundingMinesValue { get => surroundingMinesValue; set => surroundingMinesValue = value; }

        // Gets or sets a value indicating whether the surrounding cells' mines have been checked
        public bool SurroundingMinesChecked { get => surroundingMinesChecked; set => surroundingMinesChecked = value; }

    }
}
