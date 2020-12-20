using AdventOfCode2020.Inputs;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class EncodingErrorTests
    {
        [Fact]
        public void Check_if_sum_is_valid()
        {
            var _encordingError = new EncodingError();
            var check = _encordingError.doTheySum(1, 2, 3);
            var check2 = _encordingError.doTheySum(1, 2, 4);
            Assert.True(check);
            Assert.False(check2);
        }

        [Fact]
        public void Find_a_pair_that_sums()
        {
            var _encordingError = new EncodingError();
            var listOfNumbers = new List<int> { 35, 20, 15, 25, 47 };
            var find = _encordingError.findPairThatSum(listOfNumbers, 40);
            Assert.True(find);
        }

        [Fact]
        public void Find_first_invalid_number()
        {
            var _inputReader = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\09_EncodingError_Test.txt";
            var numbers = _inputReader.readNumbers(path);
            var _encodingError = new EncodingError(numbers, 5);
            Assert.Equal(127, _encodingError.findInvalidNumber());
        }

    }
}
