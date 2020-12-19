using AdventOfCode2020.Inputs;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class HandheldHaltingTests
    {

        [Fact]
        public void Should_increase_count()
        {
            var input = +5;
            var count = new HandheldHalting();
            count.accumulate(input);
            Assert.Equal(5, count.MyCount);
        }

        [Fact]
        public void Should_decrease_count()
        {
            var input = -5;
            var count = new HandheldHalting();
            count.accumulate(input);
            Assert.Equal(-5, count.MyCount);
        }

        [Fact]
        public void Should_increase_pointer()
        {
            var testList = new string[] { "aba", "bab", "cab", "dab", "eba" };
            var test = new HandheldHalting();
            var input = +3;
            test.jump(input, testList);
            Assert.Equal(3, test.Pointer);
            Assert.Equal("dab", testList[test.Pointer]);
        }

        [Fact]
        public void Should_run_instructions()
        {
            var _inputReader = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\08_HandheldHalting_Test.txt";
            var program = _inputReader.readLines(path);
            var _handheldHalting = new HandheldHalting();
            var count = _handheldHalting.runProgram(program);
            Assert.Equal(5, count.MyCount);
        }

        [Fact]
        public void Should_run_replacement_instructions()
        {
            var _inputReader = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\08_HandheldHalting_Test.txt";
            var program = _inputReader.readLines(path);
            var _handheldHalting = new HandheldHalting();
            var count = _handheldHalting.runReplacementProgram(program);
            Assert.Equal(8, count);
        }
    }
}
