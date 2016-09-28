using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    class AppEngine
    {

        // Create game.
        public void StartEngine()
        {
            //menu prompt and loop

            int choice = -1;
            while (choice == -1)
            {
                choice = UI.PromptMenu();
            }
            MakeChoice(choice);
        }

        public void MakeChoice(int choice)
        {
            GameEngine game = new GameEngine();
            // Player vs Player
            if (choice == 1)
            {
                game.PlayerVsPlayer();
            }
            // Computer vs Player
            else if (choice == 2)
            {
                game.PlayComputerVsPlayer();
            }
            // Computer vs Computer
            else if (choice == 3)
            {
                int numOfGames = 0;
                for (int i = 0; i < numOfGames; i++)
                {
                    game = new GameEngine();
                    game.PlayComputerVsComputer();
                }
            }
            else if (choice == 4)
            {
                Console.WriteLine("Goodbye");
            }
        }

        public List<List<State>> Games { get; set; }
    }
}
