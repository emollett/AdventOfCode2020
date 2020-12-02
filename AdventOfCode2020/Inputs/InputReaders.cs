using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode2020.Inputs
{
    class InputReaders
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
    }
}
