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
        public void Should_count_adaptor_differences()
        {
            var _inputReader = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\10_AdapterArray_Test.txt";
            var adapters = _inputReader.readNumbers(path);
            var _adapterArray = new AdapterArray(adapters);
            Assert.Equal(220, _adapterArray.countAdapters());
        }
    }
}
