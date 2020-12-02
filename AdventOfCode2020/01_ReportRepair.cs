using AdventOfCode2020.Inputs;
using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class ReportRepair
    {
        public List<int> AddTwoTo2020(List<int> input)
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

        public List<int> AddThreeTo2020(List<int> input)
        {
            var output = new List<int> { };
            foreach (int item in input)
            {
                var newTarget = 2020 - item;
                foreach(int item2 in input)
                {
                    if (input.Contains(newTarget - item2))
                    {
                        output.Add(item);
                        output.Add(item2);
                        output.Add(input.Find(number => number + item2 == newTarget));
                        goto Exit;
                    };
                }
            }
            Exit:
            return output;
        }

        public int Multiply(List<int> input)
        {
            var output = 1;
            foreach (int item in input)
            {
                output = output * item;
            }
            return output;
        }

        public int Problem1()
        {
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\01_01_ReportRepair.txt";
            var inputReaders = new InputReaders();
            var input = inputReaders.readNumbers(path);
            var entries = AddTwoTo2020(input);
            var total = Multiply(entries);
            return total;
        }

        public int Problem2()
        {
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\01_01_ReportRepair.txt";
            var inputReaders = new InputReaders();
            var input = inputReaders.readNumbers(path);
            var entries = AddThreeTo2020(input);
            var total = Multiply(entries);
            return total;
        }
    }
}
