using AdventOfCode2020.Inputs;
using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    public class CrabCombat
    {
        public List<int> Player1 { get; set; }
        public List<int> Player2 { get; set; }
        public int WinningScore { get;  set; }
        public List<int> Winner { get; set; }

        public CrabCombat(List<int> player1, List<int> player2)
        {
            Player1 = player1;
            Player2 = player2;
        }
        public CrabCombat(List<string> input)
        {
            Player1 = new List<int> { };
            Player2 = new List<int> { };

            var player1 = input[0].Split(' ');
            for (int i = 2; i < player1.Length; i++)
            {
                var card = player1[i];
                Player1.Add(Int32.Parse(card));
            }

            var player2 = input[1].Split(' ');
            for (int i = 2; i < player2.Length; i++)
            {
                Player2.Add(Int32.Parse(player2[i]));
            }
        }

        public CrabCombat()
        {
        }

        public void playRound()
        {
            if(Player1[0] > Player2[0])
            {
                Player1.Add(Player1[0]);
                Player1.Remove(Player1[0]);
                Player1.Add(Player2[0]);
                Player2.Remove(Player2[0]);
            }
            else
            {
                Player2.Add(Player2[0]);
                Player2.Remove(Player2[0]);
                Player2.Add(Player1[0]);
                Player1.Remove(Player1[0]);
            }
        }

        public void playGame()
        {
            while (Player1.Count != 0 && Player2.Count != 0)
            {
                playRound();
            }

            if (Player1.Count != 0) Winner = Player1;
            if (Player2.Count != 0) Winner = Player2;
        }

        public void calculateScore()
        {
            playGame();
            Winner.Reverse();
            for (int i = 0; i < Winner.Count; i++)
            {
                var score = Winner[i] * (i+1);
                WinningScore += score;
            }
        }

        public int problem1()
        {
            var _inputReader = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\22_CrabCombat.txt";
            var decks = _inputReader.readParagraphsToList(path);
            var _crabCombat = new CrabCombat(decks);
            _crabCombat.calculateScore();
            return _crabCombat.WinningScore;
        }
    }
}
