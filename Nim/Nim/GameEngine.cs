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
        private bool isTurn; 
        //create board
        public GameEngine()
        {
            //Random Turn
            isTurn = StartingTurn();
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
            TakeTurn();
        }

        public void PlayComputerVsComputer()
        {
            AI 
            TakeTurn();
        }

        public void PlayerVsPlayer()
        {
            TakeTurn();
        }

        public void RemovePieces(int targetRow, int removeAmt)
        {

        }
        public bool StartingTurn()
        {
            Random rand = new Random();
            bool boolReturn = false;
            if(rand.Next(2) == 0)
            {
                return boolReturn;
            }
            else
            {
               return !boolReturn;
            }
        }

        public void TakeTurn()
        {
            if (isTurn)
            {

            }
            else if (isTurn)
            {

            }
        }
    }

}

