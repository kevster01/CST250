using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperConsoleApp
{
    public class Program
    {
        /**
        *   Main Method carries out console application and prints out results
        */
        static void Main(string[] args)
        {

            Board game = new Board();
            game.PopulateBoard();
            game.DisplayGameBoard();

        }
    }
}
