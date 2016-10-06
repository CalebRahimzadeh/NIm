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
            return (input > 0 && input < 5) ? !isValid : isValid;
        }

        public static bool isValidRow(int input, State state)
        {
            return ((input == 1 && state.RowValues[0] > 0) || (input == 2 && state.RowValues[1] > 0) || (input == 3 && state.RowValues[2] > 0));
        }

        public static bool isValidRemoval(int row, int input, State state)
        {
            return ((row == 1 && state.RowValues[0] >= input) || (row == 2 && state.RowValues[1] >= input) || (row == 3 && state.RowValues[2] >= input));
        }

        public static bool isValidGameNumber(int input)
        {
            bool isValid = false;
            return input > 0 ? isValid = true : isValid;
        }
    }
}
