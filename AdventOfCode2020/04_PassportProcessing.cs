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
            this.byr = Regex.Split(passport, @"byr:")[1].Split(' ')[0];
            this.iyr = Regex.Split(passport, @"iyr:")[1].Split(' ')[0];
            this.eyr = Regex.Split(passport, @"eyr:")[1].Split(' ')[0];
            this.hgt = Regex.Split(passport, @"hgt:")[1].Split(' ')[0];
            this.hcl = Regex.Split(passport, @"hcl:")[1].Split(' ')[0];
            this.ecl = Regex.Split(passport, @"ecl:")[1].Split(' ')[0];
            this.pid = Regex.Split(passport, @"pid:")[1].Split(' ')[0];
            //this.cid = Regex.Split(passport, @"cid:")[1].Split(' ')[0];
        }

        public PassportProcessing()
        {
        }

        public bool checkAPassportIsPresent(string passport)
        {

            try
            {
                var checkAPassport = new PassportProcessing(passport);
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        public List<PassportProcessing> collectPassports(List<string> passports)
        {
            var presentPassports = new List<PassportProcessing> { };

            foreach (var passport in passports)
            {
                var validity = checkAPassportIsPresent(passport);
                if (validity) {
                    var presentPassport = new PassportProcessing(passport);
                    presentPassports.Add(presentPassport);
                };
            }
            return presentPassports;
        }

        public List<bool> checkIfValid(List<PassportProcessing> passports)
        {
            var validPassports = new List<bool> { };
            foreach (var passport in passports)
            {
                if (!Regex.IsMatch(passport.byr, @"(19[2-8][0-9]|199[0-9]|200[0-2])"))
                {
                    continue;
                };
                if (!Regex.IsMatch(passport.iyr, @"(201[0-9]|2020)"))
                {
                    continue;
                };
                if (!Regex.IsMatch(passport.eyr, @"(202[0-9]|2030)"))
                {
                    continue;
                };

                if (!passport.hgt.Contains("in") && !passport.hgt.Contains("cm"))
                {
                    continue;
                };
                if (passport.hgt.Contains("cm"))
                {
                    if (!Regex.IsMatch(passport.hgt, @"(1[5-8][0-9]|19[0-3])"))
                    {
                        continue;
                    };
                };
                if (passport.hgt.Contains("in"))
                {
                    if (!Regex.IsMatch(passport.hgt, @"(59|6[0-9]|7[0-6])"))
                    {
                       continue;
                    };
                };

                if (!Regex.IsMatch(passport.hcl, @"^#([0-9a-fA-F]{6})$"))
                {
                    continue;
                };

                if ( !Regex.IsMatch(passport.ecl, @"\bamb\b|\bblu\b|\bgrn\b|\bbrn\b|\bgry\b|\bhzl\b|\both\b"))
                {
                    continue;
                };

                if (!Regex.IsMatch(passport.pid, @"^[0-9]{9}$"))
                {
                    continue;
                };
                validPassports.Add(true);

            }
            return validPassports;
        }

        public int problem1()
        {
            var inputReaders = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\04_PassportProcessing.txt";
            var passports = inputReaders.readParagraphsToList(path);

            var presentPassports = collectPassports(passports);

            return presentPassports.Count;
        }

        public int problem2()
        {
            var inputReaders = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\04_PassportProcessing.txt";
            var passports = inputReaders.readParagraphsToList(path);

            var presentPassports = collectPassports(passports);
            var validPassports = checkIfValid(presentPassports);
            return validPassports.Count;
        }
    }
}
