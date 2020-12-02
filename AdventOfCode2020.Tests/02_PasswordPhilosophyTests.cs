using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class PasswordPhilosophyTests
    {
        [Fact]
        public void Password_checker_should_check_first_rules()
        {
            var input1 = new PasswordChecker("1-3 a: abcde");
            var output1 = input1.isPasswordValidFirstRuleSet();
            Assert.True(output1);

            var input2 = new PasswordChecker("1-3 b: cdefg");
            var output2 = input2.isPasswordValidFirstRuleSet();
            Assert.False(output2);

            var input3 = new PasswordChecker("2-9 c: ccccccccc");
            var output3 = input3.isPasswordValidFirstRuleSet();
            Assert.True(output3);
        }

        [Fact]
        public void Password_checker_should_check_second_rules()
        {
            var input1 = new PasswordChecker("1-3 a: abcde");
            var output1 = input1.isPasswordValidSecondRuleSet();
            Assert.True(output1);

            var input2 = new PasswordChecker("1-3 b: cdefg");
            var output2 = input2.isPasswordValidSecondRuleSet();
            Assert.False(output2);

            var input3 = new PasswordChecker("2-9 c: ccccccccc");
            var output3 = input3.isPasswordValidSecondRuleSet();
            Assert.False(output3);
        }
    }
}
