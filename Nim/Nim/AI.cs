using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    class AI : IPlayer
    {
        // history after every game
        public static Dictionary<int[], State> StateTree { get; set; } =  new Dictionary<int[], State>();
        public static double CalculateAverage()
        {
            return 0.0;
        }

        public AI(bool isTurn)
        {
            this.isTurn = isTurn;
        }

        public bool isTurn { get; set; }
    }
}
