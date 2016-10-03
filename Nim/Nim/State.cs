using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    class State
    {
        public State(int[] board)
        {
            RowValues = board;
            RowOneValue = board[0];
            RowTwoValue = board[1];
            RowThreeValue = board[2];
        }

        public int RowOneValue { get; set; }
        public int RowTwoValue { get; set; }
        public int RowThreeValue { get; set; }

        // Needs to be refactored
        public int[] RowValues { get; set; }
        
    }
}
