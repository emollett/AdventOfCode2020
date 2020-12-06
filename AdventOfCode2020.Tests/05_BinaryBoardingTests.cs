using AdventOfCode2020.Inputs;
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
            var binaryBoarding = new BinaryBoarding();
            var row = binaryBoarding.getNumber(input);
            Assert.Equal(44, row);
        }

        [Fact]
        public void Should_find_correct_column()
        {
            var input = "RLR";
            var binaryBoarding = new BinaryBoarding();
            var column = binaryBoarding.getNumber(input);
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

        [Fact]
        public void Should_be_same_number_of_tickets_and_seats()
        {
            var inputReaders = new InputReaders();
            var binaryBoarding = new BinaryBoarding();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\05_BinaryBoarding.txt";
            var tickets = inputReaders.readLines(path);

            var seats = binaryBoarding.getMultipleSeatInfo(tickets);

            Assert.Equal(tickets.Length, seats.Count);
        }
    }
}
