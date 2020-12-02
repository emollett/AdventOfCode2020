using AdventOfCode2020.Inputs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    public class PasswordChecker
    {
        public int firstNumber { get; set; }
        public int secondNumber { get; set; }
        public char rule { get; set; }
        public string password { get; set; }
        public PasswordChecker(string passwordWithRules)
        {
            //example passwordWithRules - "1-3 a: abcde"
            this.firstNumber = Int32.Parse(passwordWithRules.Split('-')[0]);
            this.secondNumber = Int32.Parse(passwordWithRules.Split('-')[1].Split(' ')[0]);
            this.rule = Convert.ToChar(passwordWithRules.Split(' ')[1].Split(':')[0]);
            this.password = passwordWithRules.Split(' ')[2];
        }

        public PasswordChecker()
        {
        }

        public bool isPasswordValidFirstRuleSet()
        {
            var letterArray = password.ToCharArray();
            var rulesInPassword = Array.FindAll(letterArray, letter => letter == rule);
            return rulesInPassword.Length >= firstNumber && rulesInPassword.Length <= secondNumber;
        }
        public bool isPasswordValidSecondRuleSet()
        {
            var letterArray = password.ToCharArray();
            return letterArray[firstNumber-1] == rule ^ letterArray[secondNumber-1] == rule;
        }

        public int checkLotsOfPasswords(string ruleSet)
        {
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\02_01_PasswordPhilosophy.txt";
            var inputReaders = new InputReaders();
            var input = inputReaders.readLines(path);

            var goodPasswordCount = 0;
            foreach(string line in input)
            {
                var passwordToCheck = new PasswordChecker(line);
                if (ruleSet == "first" ? passwordToCheck.isPasswordValidFirstRuleSet() : passwordToCheck.isPasswordValidSecondRuleSet())
                {
                    goodPasswordCount++;
                }
            }
            return goodPasswordCount;
        }
    }
}
