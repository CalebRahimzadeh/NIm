using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    class PossibleMove
    {
        public PossibleMove() { }
        public PossibleMove(int rowNum, int removeAmt)
        {
            Row = rowNum;
            NumberToRemove = removeAmt;
        }
        public int Row { get; set; }
        public int NumberToRemove { get; set; }
        public int NumberOccured { get; set; } = 1;
        public Tuple<int,int> SumScore { get; set; }

        public State RemovePieces(int[] board)
        {
            board[Row - 1] -= NumberToRemove;
            return new State(board);
        }
    }
}
