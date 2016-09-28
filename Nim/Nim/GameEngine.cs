
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
            Console.WriteLine("");
            for (int i = 0; i < _board.Length; i++)
            {
                Console.Write(i + 1);
                for (int j = 0; j < _board[i]; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        public void PlayComputerVsPlayer()
        {
            int cpuRow = 0;
            int cpuRemove = 0;
            bool gameGoing = true;
            while (gameGoing)
            {
                printBoard();
                if (currentState.RowOneValue > 0 || currentState.RowTwoValue > 0 || currentState.RowThreeValue > 0)
                {
                    SwitchTurn();
                    if(!isTurn)
                    {
                        RemovePieces(ui.PromptRow(currentState), ui.PromptRemoval(currentState));
                    } 
                    else
                    {
                        Random r = new Random();
                        cpuRow = r.Next(3) + 1;
                        if(cpuRow == 1 && currentState.RowOneValue > 0)
                        {
                            cpuRemove = r.Next(currentState.RowOneValue) + 1;
                            RemovePieces(cpuRow, cpuRemove);
                        }
                        else if (cpuRow == 2 && currentState.RowTwoValue > 0)
                        {
                            cpuRemove = r.Next(currentState.RowTwoValue) + 1;
                            RemovePieces(cpuRow, cpuRemove);
                        }
                        else if (cpuRow == 3 && currentState.RowThreeValue > 0)
                        {
                            cpuRemove = r.Next(currentState.RowThreeValue) + 1;
                            RemovePieces(cpuRow, cpuRemove);
                        }
                    }
                }
                else
                {
                    ui.gameOver(isTurn);
                    gameGoing = false;
                }
            }
        }

        public void PlayComputerVsComputer()
        {
            bool gameGoing = true;
            while (gameGoing)
            {
                printBoard();
                if (currentState.RowOneValue > 0 || currentState.RowTwoValue > 0 || currentState.RowThreeValue > 0)
                {
                    SwitchTurn();
                    RemovePieces(ui.PromptRow(currentState), ui.PromptRemoval(currentState));
                }
                else
                {
                    ui.gameOver(isTurn);
                    gameGoing = false;
                }
            }
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
                    ui.gameOver(isTurn);
                    gameGoing = false;
                }
            }
        }

        public void RemovePieces(int targetRow, int removeAmt)
        {
            _board[targetRow - 1] -= removeAmt;
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
                ui.playerTurn(isTurn);
                isTurn = !isTurn;
            }
            else if (!isTurn)
            {
                ui.playerTurn(isTurn);
                isTurn = !isTurn;
            }
            return isTurn;
        }
        // Get rid of after you preform the calculation of averages
        public List<State> GameHistory { get; set; } = new List<State>();
    }

}

