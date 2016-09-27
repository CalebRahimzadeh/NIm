using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    class UI
    {
        public static int PromptMenu()
        {
            Console.WriteLine("1: PvP\n2: PvC\n3: CVC\n4: Exit");
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


    }
}
