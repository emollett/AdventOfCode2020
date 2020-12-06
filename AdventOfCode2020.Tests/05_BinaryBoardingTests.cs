using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class BinaryBoardingTests
    {
        [Fact]
        public void Should_find_correct_row()
        {
            var input = "FBFBBFF";
            var rowsInPlane = 128;
            var binaryBoarding = new BinaryBoarding();

            var row = binaryBoarding.binarySearch(input, rowsInPlane);
            
            Assert.Equal(44, row);
        }

        [Fact]
        public void Should_find_correct_column()
        {
            var input = "RLR";
            var columnsInPlane = 8;
            var binaryBoarding = new BinaryBoarding();

            var column = binaryBoarding.binarySearch(input, columnsInPlane);

            Assert.Equal(5, column);
        }

        [Fact]
        public void Should_find_correct_seat_info()
        {
            var input = "FBFBBFFRLR";

            var binaryBoarding = new BinaryBoarding();

            var seatInfo = binaryBoarding.getSeatInfo(input);

            Assert.Equal(44, seatInfo.Row);
            Assert.Equal(5, seatInfo.Column);
            Assert.Equal(357, seatInfo.Seat);
        }
    }
}
