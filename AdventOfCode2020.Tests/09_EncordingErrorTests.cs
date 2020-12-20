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
            var listOfNumbers = new List<long> { 35, 20, 15, 25, 47 };
            var find = _encordingError.findPairThatSum(listOfNumbers, 40);
            Assert.True(find);
        }

        [Fact]
        public void Find_first_invalid_number()
        {
            var _inputReader = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\09_EncodingError_Test.txt";
            var numbers = _inputReader.readLongNumbers(path);
            var _encodingError = new EncodingError(numbers, 5);
            Assert.Equal(127, _encodingError.findInvalidNumber());
        }

        [Fact]
        public void Should_continue_adding_numbers_til_target()
        {
            var numbers = new List<long> { 1, 2, 3, 4, 5 };
            var _encordingError = new EncodingError();
            var index = _encordingError.sumToTarget(numbers, 6);
            Assert.Equal(2, index);
        }

        [Fact]
        public void Should_return_neg_if_cant_sum_to_target(){
            var numbers = new List<long> { 1, 2, 3, 4, 5 };
            var _encordingError = new EncodingError();
            var index = _encordingError.sumToTarget(numbers, 7);
            Assert.Equal(-1, index);
        }

        [Fact]
        public void Find_contiguous_run()
        {
            var _inputReader = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\09_EncodingError_Test.txt";
            var numbers = _inputReader.readLongNumbers(path);
            var _encodingError = new EncodingError(numbers, 127);
            Assert.Equal(62, _encodingError.findContiguousSet());
        }

    }
}
