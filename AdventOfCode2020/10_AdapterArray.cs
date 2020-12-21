using AdventOfCode2020.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class AdapterArray
    {
        public List<long> Adapters { get; set; }

        public AdapterArray(List<long> adapters)
        {
            Adapters = adapters;
        }

        public AdapterArray()
        {
        }

        public List<int> findJumps(List<long> adapters)
        {
            var jumps = new List<int>{};

            adapters.Add(0);
            adapters.Sort();
            adapters.Add(Adapters.Max() + 3);

            for (int i = 0; i < Adapters.Count-1; i++)
            {
                if (adapters[i + 1] - adapters[i] == 1) jumps.Add(1);
                if (adapters[i + 1] - adapters[i] == 3) jumps.Add(3);
            }
            return jumps;
        }

        public long countAdapters()
        {
            var jumps = findJumps(Adapters);
            long countOfOne = jumps.Where(a=>a==1).Count();
            long countOfThree = jumps.Where(a => a == 3).Count();
            return countOfOne * countOfThree;
        }

        static long routeMultiplier(long ones)
        {
            switch (ones)
            {
                case 0: return 1;
                case 1: return 1;
                case 2: return 2;
                case 3: return 4;
                case 4: return 7;
                default: return 0;
            }
        }

        public long countRoutes()
        {
            long numberOfOnes = 0;
            long total = 1;
            var jumps = findJumps(Adapters);

            for (int i = 0; i < jumps.Count; i++)
            {
                if (jumps[i] == 1)
                {
                    numberOfOnes++;
                }
                else
                {
                    //it seems you only get jumps of 1 or 3
                    //jumps of 3 you HAVE to land on
                    //multiply distances between necessary jumps of 3 by the numbers of routes you can take for that distance
                    total *= routeMultiplier(numberOfOnes);
                    numberOfOnes = 0;
                }
            }
            
            return total;
        }

        public long problem1()
        {
            var _inputReader = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\10_AdapterArray.txt";
            var adapters = _inputReader.readLongNumbers(path);
            var _adapterArray = new AdapterArray(adapters);
            return _adapterArray.countAdapters();
        }

        public long problem2()
        {
            var _inputReader = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\10_AdapterArray.txt";
            var adapters = _inputReader.readLongNumbers(path);
            var _adapterArray = new AdapterArray(adapters);
            return _adapterArray.countRoutes();
        }
    }
}
