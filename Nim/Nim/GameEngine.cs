
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
        private State currentState;
        private UI ui = new UI();
        //create board
        public GameEngine()
        {
            //Random Turn
            isTurn = StartingTurn();
            // Construct rows.
            _board = new int[MAX_ROWS] { 3, 5, 7 };
            currentState = new State(_board);
            GameHistory.Add(currentState);

            if (!AI.StateTree.ContainsKey(_board))
            {
                State defaultState = new State(_board) { Average = 0 };
                AI.StateTree.Add(_board, defaultState);
            }
        }
        public void printBoard()
        {
            for (int i = 0; i < _board.Length; i++)
            {
                for (int j = 0; j < _board[i]; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }
        }

        public void PlayComputerVsPlayer()
        {
            SwitchTurn();
            RemovePieces(ui.PromptRow(currentState), ui.PromptRemoval(currentState));
        }

        public void PlayComputerVsComputer()
        {
            SwitchTurn();
            RemovePieces(ui.PromptRow(currentState), ui.PromptRemoval(currentState));
        }

        public void PlayerVsPlayer()
        {
            bool gameGoing = true;
            while(gameGoing)
            {
                printBoard();
                if (currentState.RowOneValue > 0 || currentState.RowTwoValue > 0 || currentState.RowThreeValue > 0)
                {
                    SwitchTurn();
                    RemovePieces(ui.PromptRow(currentState), ui.PromptRemoval(currentState));
                }
                else
                {
                    gameGoing = false;
                }
            }

        }

        public void RemovePieces(int targetRow, int removeAmt)
        {
            _board[targetRow] -= removeAmt;
            currentState = new State(_board);
            GameHistory.Add(currentState);
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
        // Get rid of after you preform the calculation of averages
        public List<State> GameHistory { get; set; } = new List<State>();
    }

}

