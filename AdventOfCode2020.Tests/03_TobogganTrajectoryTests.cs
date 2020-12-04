using AdventOfCode2020.Inputs;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class TobogganTrajectoryTests
    {
        [Fact]
        public void Should_identify_character_at_coordinate()
        {
            var tobboganTrajectory = new TobogganTrajectory();
            var line1 = new List<char>() { 'a', 'b', 'c' };
            var line2 = new List<char>() { 'd', 'e', 'f' };
            var line3 = new List<char>() { 'h', 'i', 'j' };
            var grid = new List<List<char>>
            {
                line1, line2, line3
            };
            var travelVector = new int[] { 1, 2 };

            var output = tobboganTrajectory.moveSleigh(travelVector, grid);
            Assert.Equal('i', output[output.Count - 1]);
        }

        [Fact]
        public void Should_identify_character_at_coordinate_larger_than_grid_width()
        {
            var tobboganTrajectory = new TobogganTrajectory();
            var line1 = new List<char>() { 'a', 'b', 'c' };
            var line2 = new List<char>() { 'd', 'e', 'f' };
            var line3 = new List<char>() { 'h', 'i', 'j' };
            var grid = new List<List<char>>
            {
                line1, line2, line3
            };
            var travelVector = new int[] { 5, 2 };

            var output = tobboganTrajectory.moveSleigh(travelVector, grid);
            Assert.Equal('j', output[output.Count - 1]);
        }

        [Fact]
        public void Should_identify_character_at_coordinate_same_as_grid_width()
        {
            var tobboganTrajectory = new TobogganTrajectory();
            var line1 = new List<char>() { 'a', 'b', 'c' };
            var line2 = new List<char>() { 'd', 'e', 'f' };
            var line3 = new List<char>() { 'h', 'i', 'j' };
            var grid = new List<List<char>>
            {
                line1, line2, line3
            };
            var travelVector = new int[] { 3, 2 };

            var output = tobboganTrajectory.moveSleigh(travelVector, grid);
            Assert.Equal('h', output[output.Count - 1]);
        }

        [Fact]
        public void Should_identify_character_at_coordinate_after_moving_twice()
        {
            var tobboganTrajectory = new TobogganTrajectory();
            var line1 = new List<char>() { 'a', 'b', 'c' };
            var line2 = new List<char>() { 'd', 'e', 'f' };
            var line3 = new List<char>() { 'h', 'i', 'j' };
            var grid = new List<List<char>>
            {
                line1, line2, line3
            };
            var travelVector = new int[] { 1, 1 };

            var output = tobboganTrajectory.moveSleigh(travelVector, grid);
            Assert.Equal('j', output[output.Count - 1]);
        }

        [Fact]
        public void Should_count_trees()
        {
            var tobboganTrajectory = new TobogganTrajectory();
            var line1 = new List<char>() { 'a', 'b', 'c' };
            var line2 = new List<char>() { 'd', 'e', 'f' };
            var line3 = new List<char>() { 'h', 'i', '#' };
            var grid = new List<List<char>>
            {
                line1, line2, line3
            };
            var travelVector = new int[] { 1, 1 };

            var itemsOnRoute = tobboganTrajectory.moveSleigh(travelVector, grid);
            int output = tobboganTrajectory.countTrees(itemsOnRoute);
            Assert.Equal(1, output);
        }

        [Fact]
        public void Input_is_parsed_correctly()
        {
            var tobboganTrajectory = new TobogganTrajectory();
            var inputReaders = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\03_01_TobogganTrajectory_Test.txt";
            var grid = inputReaders.readLinesToGrid(path);
            Assert.Equal(11, grid.Count);
        }

        [Fact]
        public void Problem1_Using_example_input()
        {
            var tobboganTrajectory = new TobogganTrajectory();
            var inputReaders = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\03_01_TobogganTrajectory_Test.txt";

            var grid = inputReaders.readLinesToGrid(path);
            var travelVector = new int[] { 3, 1 };
            var itemsOnRoute = tobboganTrajectory.moveSleigh(travelVector, grid);
            Assert.Equal(10, itemsOnRoute.Count);
            int output = tobboganTrajectory.countTrees(itemsOnRoute);
            Assert.Equal(7, output);
        }

        [Fact]
        public void Return_number_of_trees_for_multiple_slopes()
        {
            var tobboganTrajectory = new TobogganTrajectory();
            var inputReaders = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\03_01_TobogganTrajectory_Test.txt";
            var grid = inputReaders.readLinesToGrid(path);

            var slope1 = new List<int>() { 1, 1 };
            var slope2 = new List<int>() { 3, 1 };
            var slope3 = new List<int>() { 5, 1 };
            var slopesToTest = new List<List<int>>
            {
                slope1, slope2, slope3
            };
            var listOfTreeCounts = tobboganTrajectory.testLotsOfSlopes(slopesToTest, grid);

            Assert.Equal(new List<int>() { 2, 7, 3 }, listOfTreeCounts);
        }

        [Fact]
        public void Multiply_number_of_trees_for_multiple_slopes()
        {
            var tobboganTrajectory = new TobogganTrajectory();
            var inputReaders = new InputReaders();
            var helpers = new Helpers();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\03_01_TobogganTrajectory_Test.txt";
            var grid = inputReaders.readLinesToGrid(path);

            var slope1 = new List<int>() { 1, 1 };
            var slope2 = new List<int>() { 3, 1 };
            var slope3 = new List<int>() { 5, 1 };
            var slope4 = new List<int>() { 7, 1 };
            var slope5 = new List<int>() { 1, 2 };
            var slopesToTest = new List<List<int>>
            {
                slope1, slope2, slope3, slope4, slope5
            };
            var listOfTreeCounts = tobboganTrajectory.testLotsOfSlopes(slopesToTest, grid);
            var total = helpers.Multiply(listOfTreeCounts);
            Assert.Equal(336, total);

        }
    }
}
