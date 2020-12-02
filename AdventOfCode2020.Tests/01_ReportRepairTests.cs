using System;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2020
{
    public class ReportRepairTests
    {
        [Fact]
        public void Return_Two_numbers_That_Sum_to_2020()
        {
            var input = new List<int> { 1721, 979, 366, 299, 675, 1456 };
            var reportRepair = new ReportRepair();
            var output = reportRepair.AddTo2020(input);
            Assert.Equal(new List<int> { 1721, 299 }, output);
        }

        [Fact]
        public void Multiply_returned_numbers()
        {
            var input = new List<int> { 1721, 299 };
            var reportRepair = new ReportRepair();
            var output = reportRepair.Multiply(input);
            Assert.Equal(514579, output);
        }

    }
}
