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
            GameEngine game = new GameEngine();

            if (choice == 1)
            {

                game.Run();
                //Pvp
            }
            else if (choice == 2)
            {
                game.PlayComputerVsPlayer();
            }
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

    }
}
