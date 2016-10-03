using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nim
{
    class InputValidation
    {

        public static bool isValidInputRange(int input)
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

        public static bool isValidRow(int input, State state)
        {
            return ((input == 1 && state.RowOneValue > 0) || (input == 2 && state.RowTwoValue > 0) || (input == 3 && state.RowThreeValue > 0));
        }

        public static bool isValidRemoval(int row, int input, State state)
        {
            return ((row == 1 && state.RowOneValue >= input) || (row == 2 && state.RowTwoValue >= input) || (row == 3 && state.RowThreeValue >= input));
        }

        public static bool isValidGameNumber(int input)
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
