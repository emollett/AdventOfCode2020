using AdventOfCode2020.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class AdapterArray
    {
        public List<int> Adapters { get; set; }

        public AdapterArray(List<int> adapters)
        {
            Adapters = adapters;
        }

        public AdapterArray()
        {
        }

        public int countAdapters()
        {
            var countOfOne = 0;
            var countOfThree = 0;

            Adapters.Add(0);
            Adapters.Sort();
            Adapters.Add(Adapters.Max() + 3);

            for (int i = 0; i < Adapters.Count-1; i++)
            {
                if (Adapters[i + 1] - Adapters[i] == 1) countOfOne++;
                if (Adapters[i + 1] - Adapters[i] == 3) countOfThree++;
            }
            return countOfOne * countOfThree;
        }

        public int problem1()
        {
            var _inputReader = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\10_AdapterArray.txt";
            var adapters = _inputReader.readNumbers(path);
            var _adapterArray = new AdapterArray(adapters);
            return _adapterArray.countAdapters();
        }
    }
}
