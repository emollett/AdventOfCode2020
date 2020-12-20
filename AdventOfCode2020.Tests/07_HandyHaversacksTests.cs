using AdventOfCode2020.Inputs;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class HandyHaversacksTests
    {

        [Fact]
        public void Should_describe_a_bag()
        {
            var input = "light red bags contain 1 bright white bag, 2 muted yellow bags.";
            var bag = new HandyHaversacks(input);
            Assert.Equal("light red", bag.description);
        }

        [Fact]
        public void Should_describe_a_bags_contents()
        {
            var input = "light red bags contain 1 bright white bag, 2 muted yellow bags.";
            var bag = new HandyHaversacks(input);
            Assert.Equal("bright white", bag.contents[0].description);
            Assert.Equal(1, bag.contents[0].number);
            Assert.Equal("muted yellow", bag.contents[1].description);
            Assert.Equal(2, bag.contents[1].number);
        }

        [Fact]
        public void Should_read_the_input_to_a_list_of_bags()
        {
            var inputReader = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\07_HandyHaversacks_Test.txt";
            var input = inputReader.readLines(path);
            var handyHaversacks = new HandyHaversacks();
            var bags = handyHaversacks.getAllTheBags(input);
            Assert.Equal(9, bags.Count);
            Assert.Equal("light red", bags[0].description);
        }

        [Fact]
        public void Should_count_how_many_bags_can_hold_gold_ones()
        {
            var inputReader = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\07_HandyHaversacks_Test.txt";
            var input = inputReader.readLines(path);
            var handyHaversacks = new HandyHaversacks();
            var bags = handyHaversacks.getAllTheBags(input);
            var numberOfGoldBags = handyHaversacks.containsBagToFind(bags, "shiny gold");
            Assert.Equal(4, numberOfGoldBags.Count);
        }

        //[Fact]
        //public void Should_count_how_many_bags_my_gold_one_can_hold()
        //{
        //    var inputReader = new InputReaders();
        //    var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\07_HandyHaversacks_Test.txt";
        //    var input = inputReader.readLines(path);
        //    var handyHaversacks = new HandyHaversacks();
        //    var bags = handyHaversacks.getAllTheBags(input);
        //    var bagsICanHold = handyHaversacks.fitInThisBag(bags, "shiny gold");
        //    Assert.Equal(32, bagsICanHold);
        //}
    }
}
