using AdventOfCode2020.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class EncodingError
    {
        public List<long> Input { get; set; }
        public int Target { get; set; }

        public EncodingError(List<long> input, int target)
        {
            Input = input;
            Target = target;
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
            for (int i = Target; i < Input.Count; i++)
            {
                var numbersToSearch = new List<long> { };
                for (int a = i-Target; a < i; a++)
                {
                    numbersToSearch.Add(Input[a]);
                }
                if (!findPairThatSum(numbersToSearch, Input[i])) return Input[i];
            }
            return -1;
        }

        public long sumToTarget(List<long> numbers, long target)
        {
            long count = 0;
            var i = 0;
            while (count < target)
            {
                count = count + numbers[i];
                if (count == target) return i;
                i++;
            }
            return -1;
        }

        public long findContiguousSet()
        {
            for (int i = 0; i < Input.Count; i++)
            {
                var end = Input.Count - i;
                long sum = sumToTarget(Input.GetRange(i, end), Target);
                if (sum != -1) return Input.GetRange(i, (int)sum).Max() + Input.GetRange(i, (int)sum).Min();
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

        public long problem2()
        {
            var _inputReader = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\09_EncodingError.txt";
            var numbers = _inputReader.readLongNumbers(path);
            var _encodingError = new EncodingError(numbers, 257342611);
            return _encodingError.findContiguousSet();
        }
    }
}
