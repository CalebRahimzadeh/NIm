
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
        State currentState; 
        UI ui = new UI();
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

        private void Run()
        {
            //play game    
            currentState = new State(_board);

        }

        public void UpdateCurrentState(State state)
        {

        }

        public void PlayComputerVsPlayer()
        {
            TakeTurn(state);
            RemovePieces(ui.PromptRow(state), ui.PromptRemoval(state));
        }

        public void PlayComputerVsComputer(State state)
        {
            TakeTurn(state);
            RemovePieces(ui.PromptRow(state), ui.PromptRemoval(state));
        }

        public void PlayerVsPlayer(State state)
        {
            TakeTurn(state);
            RemovePieces(ui.PromptRow(state), ui.PromptRemoval(state));
        }

        public void RemovePieces(int targetRow, int removeAmt)
        {
            _board[targetRow] -= removeAmt;
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

        public bool TakeTurn(State state)
        {
            if (isTurn)
            {
                isTurn = !isTurn;
            }
            else if (!isTurn)
            {
                isTurn = !isTurn;
            }
            return isTurn;
        }
    }

}

