using AdventOfCode2020.Inputs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class PassportProcessing
    {
        public string byr { get; set; }
        public string iyr { get; set; }
        public string eyr { get; set; }
        public string hgt { get; set; }
        public string hcl { get; set; }
        public string ecl { get; set; }
        public string pid { get; set; }
        public string cid { get; set; }

        public PassportProcessing(string passport)
        {
            this.byr = passport.Contains("byr") ? Regex.Split(passport, @"byr:")[1].Split(' ')[0] : null;
            this.iyr = passport.Contains("iyr") ? Regex.Split(passport, @"iyr:")[1].Split(' ')[0] : null;
            this.eyr = passport.Contains("eyr") ? Regex.Split(passport, @"eyr:")[1].Split(' ')[0] : null;
            this.hgt = passport.Contains("hgt") ? Regex.Split(passport, @"hgt:")[1].Split(' ')[0] : null;
            this.hcl = passport.Contains("hcl") ? Regex.Split(passport, @"hcl:")[1].Split(' ')[0] : null;
            this.ecl = passport.Contains("ecl") ? Regex.Split(passport, @"ecl:")[1].Split(' ')[0] : null;
            this.pid = passport.Contains("pid") ? Regex.Split(passport, @"pid:")[1].Split(' ')[0] : null;
            this.cid = passport.Contains("cid") ? Regex.Split(passport, @"cid:")[1].Split(' ')[0] : null;
        }

        public PassportProcessing()
        {
        }

        public bool checkAPassportIsPresent(string passport)
        {
            var checkAPassport = new PassportProcessing(passport);
            if (checkAPassport.byr == null || checkAPassport.iyr == null || checkAPassport.eyr == null || checkAPassport.hgt == null || checkAPassport.hcl == null || checkAPassport.ecl == null || checkAPassport.pid == null) return false;
            return true;
        }

        public int checkManyPassportsArePresent(List<string> passports)
        {
            var count = 0;
            foreach (var passport in passports)
            {
                var validity = checkAPassportIsPresent(passport);
                if (validity) count++;
            }
            return count;
        }

        public int problem1()
        {
            var inputReaders = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\04_PassportProcessing.txt";
            var passports = inputReaders.readParagraphsToList(path);

            var present = checkManyPassportsArePresent(passports);
            return present;
        }
    }
}
