using AdventOfCode2020.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2020
{
    public class BinaryBoarding
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int Seat { get; set; }
        public BinaryBoarding(int row, int column, int seat)
        {
            Row = row;
            Column = column;
            Seat = seat;
        }

        public BinaryBoarding()
        {
        }

        //public int binarySearch(string input, int rows)
        //{
        //    var lower = 0;
        //    var higher = rows;
        //    foreach (var character in input)
        //    {
        //        if(character.Equals('F')||character.Equals('L'))
        //        {
        //            higher = lower + ((higher - lower) / 2);
        //        }
        //        else
        //        {
        //            lower = lower + ((higher-lower) / 2);
        //        }
        //    }
        //    return lower;
        //}

        public int getNumber(string input)
        {
            var binaryInput = int.Parse(input.Replace('F', '0').Replace('B', '1').Replace('L', '0').Replace('R', '1'));
            var decimalOutput = Convert.ToInt32(binaryInput.ToString(), 2);
            return decimalOutput;
        }

        public BinaryBoarding getSeatInfo(string ticket)
        {
            var row = getNumber(ticket.Substring(0,7));
            var column = getNumber(ticket.Substring(7));
            var seat = (row * 8) + column;
            var seatInfo = new BinaryBoarding(row, column, seat);
            return seatInfo;   
        }

        public List<BinaryBoarding> getMultipleSeatInfo(string[] tickets)
        {
            var seats = new List<BinaryBoarding> { };

            foreach (var ticket in tickets)
            {
                var seat = getSeatInfo(ticket);
                seats.Add(seat);
            }
            return seats;
        }

        public int findHighestSeat(List<BinaryBoarding> seats)
        {
            var highestSeat = 0;
            foreach (var seat in seats)
            {
                if (seat.Seat > highestSeat) highestSeat = seat.Seat;
            }
            return highestSeat;
        }

        public int problem1()
        {
            var inputReaders = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\05_BinaryBoarding.txt";
            var tickets = inputReaders.readLines(path);

            var seats = getMultipleSeatInfo(tickets);
            var highestSeat = findHighestSeat(seats);

            return highestSeat;
        }

        public int problem2()
        {
            var inputReaders = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\05_BinaryBoarding.txt";
            var tickets = inputReaders.readLines(path);
            var seats = getMultipleSeatInfo(tickets);
            List<BinaryBoarding> orderedSeats = seats.OrderBy(s => s.Seat).ToList();

            var previousSeat = orderedSeats.First().Seat;
            foreach (var seat in orderedSeats)
            {
                if (previousSeat != seat.Seat)return previousSeat;
                previousSeat++;
            }
            return 0;
        }

    }
}
