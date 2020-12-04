using AdventOfCode2020.Inputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    public class TobogganTrajectory
    {
        public List<char> moveSleigh(int[] slope, List<List<char>> grid)
        {
            var numberOfRows = grid.Count;
            var currentRow = 0;
            var currentColumn = 0;
            var allCharacters = new List<char> { };

            while (currentRow < numberOfRows-1)
            {
                var rowToMoveTo = slope[1] + currentRow;
                var row = grid[rowToMoveTo];
                var columnToMoveTo = currentColumn + slope[0];

                if (columnToMoveTo >= row.Count)
                {
                    columnToMoveTo = (columnToMoveTo % row.Count);
                    allCharacters.Add(row[columnToMoveTo]);
                }
                else
                {
                    allCharacters.Add(row[columnToMoveTo]);
                }

                currentRow = rowToMoveTo;
                currentColumn = columnToMoveTo;
            }

            return allCharacters;
        }

        public int countTrees(List<char> itemsOnRoute)
        {
            var numberOfTrees = itemsOnRoute.FindAll(characters => characters == '#').Count;
            return numberOfTrees;
        }

        public List<int> testLotsOfSlopes(List<List<int>> slopesToTest, List<List<char>> grid)
        {
            var treesInEachSlope = new List<int> { };
            foreach (var slope in slopesToTest)
            {
                var slopeArray = new int[] { slope[0], slope[1] };
                var itemsOnRoute = moveSleigh(slopeArray, grid);
                var total = countTrees(itemsOnRoute);
                treesInEachSlope.Add(total);
            }
            return treesInEachSlope;
        }

        public int Problem1()
        {
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\03_01_TobogganTrajectory.txt";
            var inputReaders = new InputReaders();
            var input = inputReaders.readLinesToGrid(path);
            var slope = new int[] { 1, 2 };
            var itemsOnRoute = moveSleigh(slope, input);
            var total = countTrees(itemsOnRoute);
            return total;
        }

        public long Problem2()
        {
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\03_01_TobogganTrajectory.txt";
            var inputReaders = new InputReaders();
            var helpers = new Helpers();
            var input = inputReaders.readLinesToGrid(path);

            var slope1 = new List<int>() { 1, 1 };
            var slope2 = new List<int>() { 3, 1 };
            var slope3 = new List<int>() { 5, 1 };
            var slope4 = new List<int>() { 7, 1 };
            var slope5 = new List<int>() { 1, 2 };
            var slopesToTest = new List<List<int>>
            {
                slope1, slope2, slope3, slope4, slope5
            };

            var listOfTreeCounts = testLotsOfSlopes(slopesToTest, input);
            var total = helpers.Multiply(listOfTreeCounts);
            return total;
        }

    }
}
