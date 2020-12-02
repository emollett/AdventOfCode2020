using AdventOfCode2020.Inputs;
using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class ReportRepair
    {
        public List<int> AddTo2020(List<int> input)
        {
            var output = new List<int> { };
            foreach (int item in input){
                if (input.Contains(2020 - item))
                {
                    output.Add(item);
                    output.Add(input.Find(number => number + item == 2020));
                    break;
                };
            }
            return output;
        }

        public int Multiply(List<int> input)
        {
            var output = input[0] * input[1];
            return output;
        }

        public int Problem1()
        {
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\01_01_ReportRepair.txt";
            var inputReaders = new InputReaders();
            var input = inputReaders.readNumbers(path);
            var entries = AddTo2020(input);
            var total = Multiply(entries);
            return total;
        }
    }
}
