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
                if (InputValidation.isValidInputRange(input))
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
                if (InputValidation.isValidRow(input, state))
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
                if (InputValidation.isValidRemoval(row, input, state))
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
                if (InputValidation.isValidGameNumber(input))
                {
                    return input;
                }
            }
            return 0;
        }

        public void DisplayPlayerTurn(bool turn)
        {
            string turnDisplay = (turn) ? "Player 2 turn\n" : "Player 1 turn\n";
            Console.WriteLine(turnDisplay);
        }

        public void DisplayGameOver(bool turn)
        {
            string winMessage = (turn) ? "Player 1 wins!" : "Player 2 wins!";
            Console.WriteLine(winMessage);
        }
    }
}
