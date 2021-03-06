﻿
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
        private State _endState = new State(new int[] { 0, 0, 0 });
        private List<State> gameHistory = new List<State>();
        private UI ui = new UI();

        public GameEngine()
        {
            isTurn = StartingTurn();
            _board = new int[MAX_ROWS] { 3, 5, 7 };
            currentState = new State(_board);
        }
        public void PlayComputerVsPlayer()
        {
            bool gameGoing = true;
            while (gameGoing)
            {
                BoardView.PrintBoard(currentState.RowValues);
                if (currentState.RowValues[0] > 0 || currentState.RowValues[1] > 0 || currentState.RowValues[2] > 0)
                {
                    if (!AI.StateTree.ContainsKey(currentState))
                    {
                        AI.StateTree.Add(currentState, GeneratePossibleMoves(currentState));
                    }
                    SwitchTurn();
                    if (!isTurn)
                    {
                        PossibleMove playersMove = new PossibleMove(ui.PromptRow(currentState), ui.PromptRemoval(currentState));
                        currentState = playersMove.RemovePieces(currentState.RowValues);
                    }
                    else
                    {
                        var possibleMoves = GeneratePossibleMoves(currentState);
                        currentState = AI.PerformMove(currentState);
                        gameHistory.Add(currentState);
                    }
                }
                else
                {
                    CalculateSumScores();
                    AI.CalculateAverage(gameHistory);
                    ui.DisplayGameOver(isTurn);
                    gameGoing = !gameGoing;
                }

            }
        }

        public void PlayComputerVsComputer()
        {
            bool gameGoing = true;
            while (gameGoing)
            {
                BoardView.PrintBoard(currentState.RowValues);
                if (currentState.RowValues[0] > 0 || currentState.RowValues[1] > 0 || currentState.RowValues[2] > 0)
                {
                    AI.StateTree.Add(currentState, GeneratePossibleMoves(currentState));
                    SwitchTurn();
                    gameHistory.Add(currentState);
                    currentState = AI.PerformMove(currentState);
                }
                else
                {
                    CalculateSumScores();
                    AI.CalculateAverage(gameHistory);
                    ui.DisplayGameOver(isTurn);
                    gameGoing = !gameGoing;
                }
            }
        }

        public void PlayerVsPlayer()
        {
            bool gameGoing = true;
            while (gameGoing)
            {
                BoardView.PrintBoard(currentState.RowValues);
                if (currentState.RowValues[0] > 0 || currentState.RowValues[1] > 0 || currentState.RowValues[2] > 0)
                {
                    SwitchTurn();
                    PossibleMove move = new PossibleMove(ui.PromptRow(currentState), ui.PromptRemoval(currentState));
                    currentState = move.RemovePieces(currentState.RowValues);

                }
                else
                {
                    ui.DisplayGameOver(isTurn);
                    gameGoing = !gameGoing;
                }
            }
        }
        private void CalculateSumScores()
        {
            gameHistory.Add(_endState);
            bool stateIsPositive = false;
            int negCounter = 0;
            int negDenominator = gameHistory.Count / 2;
            int posDenominator = ((gameHistory.Count - negDenominator) - 1);
            int posCounter = 0;

            for (int j = gameHistory.Count; j > 1; j--)
            {
                foreach (var item in AI.StateTree[gameHistory[j]])
                {
                    if (stateIsPositive)
                    {
                        item.Key.SumScore = new Tuple<int, int>(--negCounter, negDenominator);
                    }
                    else
                    {
                        item.Key.SumScore = new Tuple<int, int>(++posCounter, posDenominator);
                    }
                    item.Key.NumberOccured++;
                }
            }
        }
        public Dictionary<PossibleMove, double> GeneratePossibleMoves(State currentState)
        {
            Dictionary<PossibleMove, double> statesPosMoves = new Dictionary<PossibleMove, double>();
            int removalLimit = 3;
            for (int i = 1; i <= MAX_ROWS; i++)
            {
                if (i == 2)
                {
                    removalLimit = 5;
                }
                else if (i == 3)
                {
                    removalLimit = 7;
                }

                for (int j = 1; j < removalLimit; j++)
                {
                    PossibleMove posMove = new PossibleMove(i, j);
                    if (!statesPosMoves.ContainsKey(posMove))
                    {
                        statesPosMoves.Add(posMove, 0);
                    }
                }
            }
            return statesPosMoves;
        }

        public bool StartingTurn()
        {
            Random rand = new Random();
            return rand.Next(2) == 0;
        }

        public bool SwitchTurn()
        {
            ui.DisplayPlayerTurn(isTurn);
            isTurn = !isTurn;
            return isTurn;
        }

    }
}

