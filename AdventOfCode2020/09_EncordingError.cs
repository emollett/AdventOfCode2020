using AdventOfCode2020.Inputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    public class EncodingError
    {
        public List<long> Input { get; set; }
        public int Preamble { get; set; }

        public EncodingError(List<long> input, int preamble)
        {
            Input = input;
            Preamble = preamble;
        }

        public EncodingError()
        {
        }

        public bool doTheySum(long a, long b, long target)
        {
            if (a + b == target) return true;
            return false;
        }

        public bool findPairThatSum(List<long> numbersToSearch, long target)
        {
            foreach (var item in numbersToSearch)
            {
                foreach (var secondItem in numbersToSearch)
                {
                    if (doTheySum(item, secondItem, target) && item != secondItem) return true;
                }
            }
            return false;
        }

        public long findInvalidNumber()
        {
            for (int i = Preamble; i < Input.Count; i++)
            {
                var numbersToSearch = new List<long> { };
                for (int a = i-Preamble; a < i; a++)
                {
                    numbersToSearch.Add(Input[a]);
                }
                if (!findPairThatSum(numbersToSearch, Input[i])) return Input[i];
            }
            return -1;
        }

        public long problem1()
        {
            var _inputReader = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\09_EncodingError.txt";
            var numbers = _inputReader.readLongNumbers(path);
            var _encodingError = new EncodingError(numbers, 25);
            return _encodingError.findInvalidNumber();
        }
    }
}
