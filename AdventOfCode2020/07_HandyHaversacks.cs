using AdventOfCode2020.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    public class HandyHaversacks
    {
        public string description { get; set; }
        public List<HandyHaversacks> contents { get; set; }
        public int number { get; set; }

        public HandyHaversacks(string input)
        {
            this.description = input.Replace("bags", ":").Split(':')[0].Trim();
            this.contents = getBagContents(input);
            this.number = 0;
        }

        public HandyHaversacks(string input, int number)
        {
            this.description = input;
            this.contents = null;
            this.number = number;
        }

        public HandyHaversacks()
        {
        }

        private List<HandyHaversacks> getBagContents(string input)
        {
            var contentString = input.Replace("contain", ":").Split(':')[1];
            var contents = contentString.Split(',');
            var formattedContents = new List<HandyHaversacks> { };
            foreach (var content in contents)
            {
                var cleanedContent = Regex.Replace(content, @"[\d-]", string.Empty).Replace("bags", "").Replace("bag", "").Replace(".", "").Trim();
                var number = Int32.Parse(Regex.Match(content.Replace("no", "0"), @"[\d-]").Value);
                var bag = new HandyHaversacks(cleanedContent, number);
                formattedContents.Add(bag);
            }
            return formattedContents;
        }

        public List<HandyHaversacks> getAllTheBags(string[] input)
        {
            var listOfBags = new List<HandyHaversacks> { };
            foreach (var item in input)
            {
                var bag = new HandyHaversacks(item);
                listOfBags.Add(bag);
            }
            return listOfBags;
        }

        public HashSet<HandyHaversacks> containsBagToFind(List<HandyHaversacks> bags, string bagToFind)
        {
            var bagsThatHoldGoldBags = new List<HandyHaversacks> { };
            foreach (var bag in bags)
            {
                foreach (var contents in bag.contents)
                {
                    if (contents.description == bagToFind) {
                        bagsThatHoldGoldBags.Add(bag);
                        var nextBags = containsBagToFind(bags, bag.description);
                        foreach (var innerBag in nextBags)
                        {
                            bagsThatHoldGoldBags.Add(innerBag);
                        }
                        };
                }
            }
            var hashOfBags = new HashSet<HandyHaversacks>(bagsThatHoldGoldBags);
            return hashOfBags;
        }

        //public int fitInThisBag(List<HandyHaversacks> bags, string myBigBag)
        //{

        //}

        public int problem1()
        {
            var inputReader = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\07_HandyHaversacks.txt";
            var input = inputReader.readLines(path);
            var bags = getAllTheBags(input);
            var numberOfGoldBags = containsBagToFind(bags, "shiny gold");
            return numberOfGoldBags.Count;
        }
    }
}
