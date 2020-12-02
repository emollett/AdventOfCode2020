using AdventOfCode2020;
using System;

namespace AdventOfCodeAnswers
{
    class Program
    {
        static void Main()
        {
            var day2 = new PasswordChecker();
            var day2Problem1 = day2.checkLotsOfPasswords("first");
            Console.WriteLine(day2Problem1);
            var day2Problem2 = day2.checkLotsOfPasswords("second");
            Console.WriteLine(day2Problem2);

            //var day1 = new ReportRepair();
            //var day1Problem1 = day1.Problem1();
            //Console.WriteLine(day1Problem1);
            //var day1Problem2 = day1.Problem2();
            //Console.WriteLine(day1Problem2);
        }
    }
}
