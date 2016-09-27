using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    class GameEngine
    {
        private const int MAX_ROWS = 3;
        private int[] _board;
        //create board
        public GameEngine()
        {
            // Construct rows.
            _board = new int[MAX_ROWS] { 3, 5, 7 };
            if (!AI.StateTree.ContainsKey(_board))
            {
                State defaultState = new State(_board) { Average = 0 };
                AI.StateTree.Add(_board, defaultState);
            }
        }

        public void Run()
        {

            //play game     
            State currentState = new State(_board);
        }

        public void PlayComputerVsPlayer()
        {

        }

        public void PlayComputerVsComputer()
        {

        }

        public void RemovePieces(int targetRow, int removeAmt)
        {

        }
    }
}
