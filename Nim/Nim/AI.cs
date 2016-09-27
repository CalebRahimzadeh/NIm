using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    class AI : IPlayer
    {
        public static Dictionary<int[], State> StateTree { get; set; } =  new Dictionary<int[], State>();
        public AI()
        {

        }

        public bool IsTurn()
        {
            throw new NotImplementedException();
        }
    }
}
