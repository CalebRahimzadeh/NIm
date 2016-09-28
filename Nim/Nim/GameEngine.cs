
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
        private bool contGame;
        private State currentState;
        private UI ui = new UI();
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

        public void UpdateCurrentState()
        {

        }

        public void PlayComputerVsPlayer()
        {
            //True means Player1, Player1 is always the human
            SwitchTurn();
            if (isTurn) { RemovePieces(ui.PromptRow(currentState), ui.PromptRemoval(currentState)); }

        }

        public void PlayComputerVsComputer()
        {
            SwitchTurn();
            RemovePieces(ui.PromptRow(currentState), ui.PromptRemoval(currentState));
        }

        public void PlayerVsPlayer()
        {
            if(currentState.RowOneValue > 0 || currentState.RowTwoValue > 0 || currentState.RowThreeValue > 0)
            {
                SwitchTurn();
                RemovePieces(ui.PromptRow(currentState), ui.PromptRemoval(currentState));
            }
        }

        public void RemovePieces(int targetRow, int removeAmt)
        {
            _board[targetRow] -= removeAmt;
        }

        public bool StartingTurn()
        {
            Random rand = new Random();
            bool boolReturn = false;
            if (rand.Next(2) == 0)
            {
                return boolReturn;
            }
            else
            {
                return !boolReturn;
            }
        }

        public bool SwitchTurn()
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

    public List<State> GameHistory { get; set; }

}

