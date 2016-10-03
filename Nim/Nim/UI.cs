using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    class UI
    {
        public int row;
        public static int PromptMenu()
        {
            Console.WriteLine("1: PvP\n2: PvC\n3: CVC\n4: Exit\n");
            int input;
            if (int.TryParse(Console.ReadLine(), out input))
            {
                if (isValidInputRange(input))
                {
                    return input;
                }
            }
            return -1;
        }
        public int PromptRow(State state)
        {
            Console.WriteLine("Which row are you modifying? (1, 2, 3)\n");
            int input;
            if (int.TryParse(Console.ReadLine(), out input))
            {
                row = input;
                if (isValidRow(input, state))
                {
                    return input;
                }
            }
            return 0;
        }

        public int PromptRemoval(State state)
        {
            Console.WriteLine("How many pieces are you removing?\n");
            int input;
            if (int.TryParse(Console.ReadLine(), out input))
            {
                if (isValidRemoval(input, state))
                {
                    return input;
                }
            }
            return 0;
        }

        public static int PromptGameNumberAI()
        {
            Console.WriteLine("How many games would you like to be played?\n");
            int input;
            if (int.TryParse(Console.ReadLine(), out input))
            {
                if (isValidGameNumber(input))
                {
                    return input;
                }
            }
            return 0;
        }

        private static bool isValidInputRange(int input)
        {
            bool isValid = false;
            if (input > 0 && input < 5)
            {
                return !isValid;
            }
            else
            {
                return isValid;
            }
        }

        private static bool isValidRow(int input, State state)
        {
            return ((input == 1 && state.RowValues[0] > 0) || (input == 2 && state.RowValues[1] > 0) || (input == 3 && state.RowValues[2] > 0));
        }

        private bool isValidRemoval(int input, State state)
        {
            return ((row == 1 && state.RowValues[0] >= input) || (row == 2 && state.RowValues[1] >= input) || (row == 3 && state.RowValues[2] >= input));
        }

        private static bool isValidGameNumber(int input)
        {
            bool isValid = false;
            if (input > 0)
            {
                isValid = true;
            }
            return isValid;
        }

        public void playerTurn(bool turn)
        {
            if (!turn)
            {
                Console.WriteLine("Player 1 turn\n");
            }
            else if (turn)
            {
                Console.WriteLine("Player 2 turn\n");
            }
        }

        public void gameOver(bool turn)
        {
            if(!turn)
            {
                Console.WriteLine("Player 1 wins!");
            } else if (turn)
            {
                Console.WriteLine("Player 2 wins!");
            }
        }
    }
}
