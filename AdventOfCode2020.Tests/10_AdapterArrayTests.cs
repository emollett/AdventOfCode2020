using AdventOfCode2020.Inputs;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class AdapterArrayTests
    {
        [Fact]
        public void Should_count_adapter_differences_small_example()
        {
            var adapters = new List<long> { 16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4 };
            var _adapterArray = new AdapterArray(adapters);
            Assert.Equal(35, _adapterArray.countAdapters());
        }

        [Fact]
        public void Should_count_adaptor_differences()
        {
            var _inputReader = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\10_AdapterArray_Test.txt";
            var adapters = _inputReader.readLongNumbers(path);
            var _adapterArray = new AdapterArray(adapters);
            Assert.Equal(220, _adapterArray.countAdapters());
        }

        [Fact]
        public void Should_count_route_permutations_small_example()
        {
            var adapters = new List<long> { 16, 10, 15, 5, 1, 11, 7, 19, 6, 12, 4 };
            var _adapterArray = new AdapterArray(adapters);
            Assert.Equal(8, _adapterArray.countRoutes());
        }

        [Fact]
        public void Should_count_route_permutations()
        {
            var _inputReader = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\10_AdapterArray_Test.txt";
            var adapters = _inputReader.readLongNumbers(path);
            var _adapterArray = new AdapterArray(adapters);
            Assert.Equal(19208, _adapterArray.countRoutes());
        }
    }
}
