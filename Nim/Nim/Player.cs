using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    class Player
    {
        public Player(bool isTurn)
        {
            this.isTurn = isTurn;
        }

        public bool isTurn { get; set; }

    }
}
