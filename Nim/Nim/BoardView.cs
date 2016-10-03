using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    class BoardView
    {
        public static void PrintBoard(int[] _board)
        {
            Console.WriteLine("");
            for (int i = 0; i < _board.Length; i++)
            {
                Console.Write(i + 1);
                for (int j = 0; j < _board[i]; j++)
                {
                    Console.Write("X");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        internal static void PrintBoard()
        {
            throw new NotImplementedException();
        }
    }
}
