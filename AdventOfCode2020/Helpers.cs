using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    public class Helpers
    {
        public long Multiply(List<int> input)
        {
            long output = 1;
            foreach (int item in input)
            {
                output = output * item;
            }
            return output;
        }
    }
}
