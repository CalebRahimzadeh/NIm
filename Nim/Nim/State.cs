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
        }
        public int[] RowValues { get; set; }
    }
}
