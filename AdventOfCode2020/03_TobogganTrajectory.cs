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

        public int Problem1()
        {
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\03_01_TobogganTrajectory.txt";
            var inputReaders = new InputReaders();
            var input = inputReaders.readLinesToGrid(path);
            var slope = new int[] { 3, 1 };
            var itemsOnRoute = moveSleigh(slope, input);
            var total = countTrees(itemsOnRoute);
            return total;
        }
    }
}
