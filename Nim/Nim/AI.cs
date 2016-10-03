using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    class AI : IPlayer
    {
        //public static Dictionary<int[], State> StateTree { get; set; } =  new Dictionary<int[], State>();
        public static Dictionary<State, Dictionary<PossibleMove, double>> StateTree { get; set; } = new Dictionary<State, Dictionary<PossibleMove, double>>();
        public static double CalculateAverage(List<State> gameHistory)
        {
            double average = 0;
            foreach (var state in gameHistory)
            {
                foreach (var move in StateTree[state].Keys)
                {
                    //calculate move average
                    double convertedToDecimal = (move.SumScore.Item1 / move.SumScore.Item2);
                    double oldAvg = StateTree[state][move];
                    average = oldAvg + ((convertedToDecimal - oldAvg) / move.NumberOccured);

                    StateTree[state][move] = average;
                }
            }

            return average;
        }

        public static State PerformMove(State currentState)
        {
            PossibleMove move = CheckPossibleMoves(currentState);
            ++move.NumberOccured;
            return move.RemovePieces(currentState.RowValues);
        }
        private static PossibleMove CheckPossibleMoves(State currentState)
        {
            var possibleMoves = StateTree[currentState];
            PossibleMove bestMove = ChooseRandomMove(currentState);

            foreach (var move in possibleMoves.Keys)
            {
                if (possibleMoves[move] > possibleMoves[bestMove])
                {
                    bestMove = move;
                }
            }
            return bestMove;
        }
        private static PossibleMove ChooseRandomMove(State currentState)
        {
            //maybe return a state
            Random r = new Random();
            int cpuRow = r.Next(2) + 1;
            int cpuRemove = 0;
            if (cpuRow == 1 && currentState.RowOneValue > 0)
            {
                cpuRemove = r.Next(currentState.RowOneValue) + 1;
            }
            else if (cpuRow == 2 && currentState.RowTwoValue > 0)
            {
                cpuRemove = r.Next(currentState.RowTwoValue) + 1;
            }
            else if (cpuRow == 3 && currentState.RowThreeValue > 0)
            {
                cpuRemove = r.Next(currentState.RowThreeValue) + 1;
            }

            return new PossibleMove(cpuRow, cpuRemove);
        }
        public bool isTurn { get; set; }
    }
}
