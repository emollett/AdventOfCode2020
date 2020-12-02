using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class PasswordPhilosophyTests
    {
        [Fact]
        public void Password_checker_should_check_rules()
        {
            var input1 = new PasswordChecker("1-3 a: abcde");
            var output1 = input1.isPasswordValid();
            Assert.True(output1);

            var input2 = new PasswordChecker("1-3 b: cdefg");
            var output2 = input2.isPasswordValid();
            Assert.False(output2);

            var input3 = new PasswordChecker("2-9 c: ccccccccc");
            var output3 = input3.isPasswordValid();
            Assert.True(output3);
        }
    }
}
