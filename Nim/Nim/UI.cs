﻿using System;
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

        public static int PromptRow(State state)
        {
            Console.WriteLine("Which row are you modifying? (1, 2, 3)");
            int input;
            if (int.TryParse(Console.ReadLine(), out input))
            {
                if (isValidRow(input, state))
                {
                    return input;
                }
            }
            return 0;
        }

        public static int PromptRemoval(State state)
        {
            Console.WriteLine("How many pieces are you removing?");
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
            Console.WriteLine("How many games would you like to be played?");
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
            return ((input == 1 && state.RowOneValue > 0) || (input == 2 && state.RowTwoValue > 0) || (input == 3 && state.RowThreeValue > 0));
        }

        private static bool isValidRemoval(int input, State state)
        {
            //if row pieces >= removal number
            return ((state.RowOneValue >= input) || (state.RowTwoValue >= input) || (state.RowThreeValue >= input));
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


    }
}
