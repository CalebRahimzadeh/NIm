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
            GameEngine game = new GameEngine();
            game.Run();
        }


    }
}
