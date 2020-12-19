using AdventOfCode2020.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class HandheldHalting
    {
        public int MyCount { get; set; }
        public int Pointer { get; set; }

        public HandheldHalting()
        {
            MyCount = 0;
            Pointer = 0;
        }

        public int accumulate(int input)
        {
            MyCount = MyCount + input;
            return MyCount;
        }

        public int jump(int input, string[] program)
        {
            Pointer = Pointer + input;
            return Pointer;
        }

        public (int, int) runInstruction(string instruction, string[] program)
        {
            var instructionType = instruction.Split(' ')[0];
            int value = Int32.Parse(instruction.Split(' ')[1]);

            if(instructionType == "nop")
            {
                Pointer++;
                return ( MyCount, Pointer);
            }

            else if(instructionType == "acc")
            {
                MyCount = accumulate(value);
                Pointer++;
                return ( MyCount, Pointer);
            }

            else if(instructionType == "jmp")
            {
                Pointer = jump(value, program);
                return (MyCount, Pointer);
            }

            else
            {
                return (MyCount, Pointer);
            }
        }

        public (int MyCount, int Pointer) runProgram(string[] program)
        {
            var pointersUsed = new List<int> { };

            while (pointersUsed.Count == (from x in pointersUsed select x).Distinct().Count())
            {
                if (Pointer == program.Length) return (MyCount, Pointer);
                runInstruction(program[Pointer], program);
                pointersUsed.Add(Pointer);
            }

            return (MyCount, Pointer);
        }

        public int runReplacementProgram(string[] program)
        {
            for (int i = 0; i < program.Length; i++)
            {
                var cleanProgram = program.ToArray();

                if (cleanProgram[i].Split(' ')[0] == "nop")
                {
                    var newInstruction = "jmp " + cleanProgram[i].Split(' ')[1];
                    cleanProgram[i] = newInstruction;
                }
                if (cleanProgram[i].Split(' ')[0] == "jmp")
                {
                    var newInstruction = "nop " + cleanProgram[i].Split(' ')[1];
                    cleanProgram[i] = newInstruction;
                }

                MyCount = 0;
                Pointer = 0;
                runProgram(cleanProgram);

                if (Pointer == cleanProgram.Length)
                {
                    return MyCount;
                }
            }

            return 0;
        }

        public int problem1()
        {
            var _inputReader = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\08_HandheldHalting.txt";
            var program = _inputReader.readLines(path);
            var problem1Answer = runProgram(program);
            return problem1Answer.MyCount;
        }

        public int problem2()
        {
            var _inputReader = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\08_HandheldHalting.txt";
            var program = _inputReader.readLines(path);
            var problem2Answer = runReplacementProgram(program);
            return problem2Answer;
        }
    }
}
