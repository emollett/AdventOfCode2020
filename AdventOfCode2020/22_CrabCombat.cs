using AdventOfCode2020.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public class CrabCombat
    {
        public List<int> Player1 { get; set; }
        public List<int> Player2 { get; set; }
        public List<int> GameWinner { get; set; }
        public List<int> DeckMemoryPlayer1 { get; set; }
        public List<int> DeckMemoryPlayer2 { get; set; }
        public Stack<int[]> SavedPlayer1Decks { get; set; }
        public Stack<int[]> SavedPlayer2Decks { get; set; }
        public Stack<int[]> SavedPlayer1DeckMemory { get; set; }
        public Stack<int[]> SavedPlayer2DeckMemory { get; set; }

        public CrabCombat(List<int> player1, List<int> player2)
        {
            Player1 = player1;
            Player2 = player2;
            DeckMemoryPlayer1 = new List<int> { 0 };
            DeckMemoryPlayer2 = new List<int> { 0 };
            SavedPlayer1Decks = new Stack<int[]> { };
            SavedPlayer2Decks = new Stack<int[]> { };
            SavedPlayer1DeckMemory = new Stack<int[]> { };
            SavedPlayer2DeckMemory = new Stack<int[]> { };
        }
        public CrabCombat(List<string> input)
        {
            Player1 = new List<int> { };
            Player2 = new List<int> { };
            DeckMemoryPlayer1 = new List<int> { 0 };
            DeckMemoryPlayer2 = new List<int> { 0 };
            SavedPlayer1Decks = new Stack<int[]> { };
            SavedPlayer2Decks = new Stack<int[]> { };
            SavedPlayer1DeckMemory = new Stack<int[]> { };
            SavedPlayer2DeckMemory = new Stack<int[]> { };

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

        public void player1WinsRound()
        {
            Player1.Add(Player1[0]);
            Player1.Remove(Player1[0]);
            Player1.Add(Player2[0]);
            Player2.Remove(Player2[0]);
        }

        public void player2WinsRound()
        {
            Player2.Add(Player2[0]);
            Player2.Remove(Player2[0]);
            Player2.Add(Player1[0]);
            Player1.Remove(Player1[0]);
        }

        public void playRoundGame1()
        {
            if (Player1[0] > Player2[0])
            {
                player1WinsRound();
            }
            else
            {
                player2WinsRound();
            }
        }

        public void playRoundGame2()
        {
            // Play a recursive subgame if they have more cards than their card count
            if(Player1.Count > Player1[0] && Player2.Count > Player2[0])
            {
                // Save the current deck for when you return to the previous game
                int[] player1DeckForSafekeeping = Player1.ToArray();
                int[] player2DeckForSafekeeping = Player2.ToArray();
                SavedPlayer1Decks.Push(player1DeckForSafekeeping);
                SavedPlayer2Decks.Push(player2DeckForSafekeeping);

                // Ditto with the deck memory (deck memory is only in game, not between games)
                int[] player1DeckMemoryForSafeKeeping = DeckMemoryPlayer1.ToArray();
                int[] player2DeckMemoryForSafeKeeping = DeckMemoryPlayer2.ToArray();
                SavedPlayer1DeckMemory.Push(player1DeckMemoryForSafeKeeping);
                SavedPlayer2DeckMemory.Push(player2DeckMemoryForSafeKeeping);

                // Getting the new deck and new deck memory for the new game
                Player1 = Player1.GetRange(1, Player1[0]);
                Player2 = Player2.GetRange(1, Player2[0]);
                DeckMemoryPlayer1.Clear();
                DeckMemoryPlayer2.Clear();
                
                playGame2();

                if (GameWinner == Player1)
                {
                    // Has to be after to check gamewinner, but before you reorder things
                    Player1 = SavedPlayer1Decks.Pop().ToList();
                    Player2 = SavedPlayer2Decks.Pop().ToList();

                    player1WinsRound();
                }
                if (GameWinner == Player2)
                {
                    // Has to be after to check gamewinner, but before you reorder things
                    Player1 = SavedPlayer1Decks.Pop().ToList();
                    Player2 = SavedPlayer2Decks.Pop().ToList();

                    player2WinsRound();
                }

                //Tidy things up ready for the next go around
                DeckMemoryPlayer1 = SavedPlayer1DeckMemory.Pop().ToList();
                DeckMemoryPlayer2 = SavedPlayer2DeckMemory.Pop().ToList();
                GameWinner = null;
            }
            else
            {
                if (Player1[0] > Player2[0])
                {
                    player1WinsRound();
                }
                else
                {
                    player2WinsRound();
                }
            }

        }

        public void playGame1()
        {
            while (Player1.Count != 0 && Player2.Count != 0)
            {
                playRoundGame1();
            }

            if (Player1.Count != 0) GameWinner = Player1;
            if (Player2.Count != 0) GameWinner = Player2;
        }

        public void playGame2()
        {
            while (Player1.Count != 0 && Player2.Count != 0)
            {
                // If there is a previous round with the same cards in the same order for the same players, game ends in with for P1
                var roundidPlayer1 = calculateScore(Player1);
                var roundidPlayer2 = calculateScore(Player2);
                if (DeckMemoryPlayer1.Contains(roundidPlayer1) && DeckMemoryPlayer2.Contains(roundidPlayer2))
                {
                    GameWinner = Player1;
                    break;
                }
                DeckMemoryPlayer1.Add(roundidPlayer1);
                DeckMemoryPlayer2.Add(roundidPlayer2);

                playRoundGame2();
            }

            if (GameWinner == null)
            {
                if (Player1.Count != 0) GameWinner = Player1;
                if (Player2.Count != 0) GameWinner = Player2;
            }

        }

        public int calculateScore(List<int> cards)
        {
            cards.Reverse();

            var runningScore = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                var score = cards[i] * (i+1);
                runningScore += score;
            }
            cards.Reverse();
            return runningScore;
        }

        public int problem1()
        {
            var _inputReader = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\22_CrabCombat.txt";
            var decks = _inputReader.readParagraphsToList(path);
            var _crabCombat = new CrabCombat(decks);
            _crabCombat.playGame1();
            var score = _crabCombat.calculateScore(_crabCombat.GameWinner);
            return score;
        }

        public int problem2()
        {
            // Current state 20/12/24 - the tests pass but I'm not getting the correct solution ¯\_(ツ)_/¯

            var _inputReader = new InputReaders();
            var path = @"C:\Users\emollett\Documents\sites\AdventOfCode2020\AdventOfCode2020\Inputs\22_CrabCombat.txt";
            var decks = _inputReader.readParagraphsToList(path);
            var _crabCombat = new CrabCombat(decks);
            _crabCombat.playGame2();
            var score = _crabCombat.calculateScore(_crabCombat.GameWinner);
            return score;
        }
    }
}
