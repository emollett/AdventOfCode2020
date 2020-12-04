using AdventOfCode2020.Inputs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class PassportProcessingTests
    {

        [Fact]
        public void Should_split_passport_feed_by_blank_lines()
        {
            var inputReaders = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\04_PassportProcessing_Test2.txt";
            var listOfParagraphs = inputReaders.readParagraphsToList(path);
            
            var firstString = "Eleanor Mollett";
            var secondString = "Catherine Mollett";
            var blah = new List<string> {firstString, secondString };
            Assert.Equal(blah, listOfParagraphs);
        }

        [Fact]
        public void Should_read_a_passport()
        {
            var inputReaders = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\04_PassportProcessing_Test.txt";
            var passports = inputReaders.readParagraphsToList(path);

            var passport = new PassportProcessing(passports[0]);
            Assert.Equal("1937", passport.byr);
            Assert.Equal("gry", passport.ecl);
        }

        [Fact]
        public void Should_approve_a_passport()
        {
            var inputReaders = new InputReaders();
            var passportProcessing = new PassportProcessing();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\04_PassportProcessing_Test.txt";
            var passports = inputReaders.readParagraphsToList(path);

            var isAPassport = passportProcessing.checkAPassportIsPresent(passports[0]);
            Assert.True(isAPassport);
        }

        [Fact]
        public void Should_not_approve_non_passport()
        {
            var inputReaders = new InputReaders();
            var passportProcessing = new PassportProcessing();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\04_PassportProcessing_Test.txt";
            var passports = inputReaders.readParagraphsToList(path);

            var notPassport = passportProcessing.checkAPassportIsPresent(passports[1]);
            Assert.False(notPassport);
        }

        [Fact]
        public void Should_count_present_passports()
        {
            var inputReaders = new InputReaders();
            var passportProcessing = new PassportProcessing();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\04_PassportProcessing_Test.txt";
            var passports = inputReaders.readParagraphsToList(path);

            var present = passportProcessing.checkManyPassportsArePresent(passports);
            Assert.Equal(2, present);
        }
    }
}
