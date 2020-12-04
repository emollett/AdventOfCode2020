using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2020.Inputs
{
    public class InputReaders
    {
        public List<int> readNumbers(string path)
        {
            var problemInput = new List<int> { };
            string[] readText = File.ReadAllLines(path);
            foreach (string s in readText)
            {
                problemInput.Add(Int32.Parse(s));
            };
            return problemInput;
        }

        public string[] readLines(string path)
        {
            string[] problemInput = File.ReadAllLines(path);
            return problemInput;
        }

        public List<List<char>> readLinesToGrid(string path)
        {
            string[] problemInput = File.ReadAllLines(path);
            List<List<char>> grid = new List<List<char>>();

            foreach(string line in problemInput)
            {
                List<char> row = new List<char>();
                row.AddRange(line);
                grid.Add(row);
            }

            return grid;
        }
    }
}
