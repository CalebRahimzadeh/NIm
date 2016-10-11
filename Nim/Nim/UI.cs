using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    class UI
    {
        private int row;
        public static int PromptMenu()
        {
            Console.WriteLine("1: PvP\n2: PvC\n3: CVC\n4: Exit\n");
            int menuSelectionInput;
            return int.TryParse(Console.ReadLine(), out menuSelectionInput) && InputValidation.isValidInputRange(menuSelectionInput) ? menuSelectionInput : -1;
        }
        public int PromptRow(State state)
        {
            Console.WriteLine("Which row are you modifying? (1, 2, 3)\n");
            int rowSelectionInput;
            row = int.TryParse(Console.ReadLine(), out rowSelectionInput) && InputValidation.isValidRow(rowSelectionInput, state) ? rowSelectionInput : 0;
            return row;
        }

        public int PromptRemoval(State state)
        {
            Console.WriteLine("How many pieces are you removing?\n");
            int rowRemovalInput;
            return int.TryParse(Console.ReadLine(), out rowRemovalInputput) && InputValidation.isValidRemoval(row, rowRemovalInput, state) ? rowRemovalInput : 0;
        }

        public static int PromptGameNumberAI()
        {
            Console.WriteLine("How many games would you like to be played?\n");
            int numOfGamesToPlay;
            return int.TryParse(Console.ReadLine(), out numOfGamesToPlay) && InputValidation.isValidGameNumber(numOfGamesToPlay) ? numOfGamesToPlay : 0;
        }

        public void DisplayPlayerTurn(bool turn)
        {
            string currentTurnOutput = (turn) ? "Player 2 turn\n" : "Player 1 turn\n";
            Console.WriteLine(currentTurnOutput);
        }

        public void DisplayGameOver(bool turn)
        {
            string winMessage = (turn) ? "Player 1 wins!" : "Player 2 wins!";
            Console.WriteLine(winMessage);
        }
    }
}
