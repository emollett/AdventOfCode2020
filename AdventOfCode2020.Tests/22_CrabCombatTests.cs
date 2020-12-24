using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2020.Tests
{
    public class CrabCombatTests
    {
        [Fact]
        public void Should_play_a_round()
        {
            var player1 = new List<int> { 9 };
            var player2 = new List<int> { 5 };
            var _crabCombat = new CrabCombat(player1, player2);
            _crabCombat.playRoundGame1();
            Assert.Equal(2, _crabCombat.Player1.Count);
            Assert.Empty(_crabCombat.Player2);
        }

        [Fact]
        public void Should_play_game1_until_deck_empty()
        {
            var player1 = new List<int> { 9, 2, 6, 3, 1 };
            var player2 = new List<int> { 5, 8, 4, 7, 10 };
            var _crabCombat = new CrabCombat(player1, player2);
            _crabCombat.playGame1();
            Assert.Equal(10, _crabCombat.Player2.Count);
            Assert.Empty(_crabCombat.Player1);
        }

        [Fact]
        public void Should_calculate_winners_score()
        {
            var player1 = new List<int> { 9, 2, 6, 3, 1 };
            var player2 = new List<int> { 5, 8, 4, 7, 10 };
            var _crabCombat = new CrabCombat(player1, player2);
            _crabCombat.playGame1();
            var score = _crabCombat.calculateScore(_crabCombat.GameWinner);
            Assert.Equal(306, score);
        }

        [Fact]
        public void Player_1_should_win_if_decks_reoccur()
        {
            var player1 = new List<int> { 43, 19 };
            var player2 = new List<int> { 2, 29, 14 };
            var _crabCombat = new CrabCombat(player1, player2);
            _crabCombat.playGame2();
            Assert.Equal(2, _crabCombat.Player1.Count);
            Assert.Equal(3, _crabCombat.Player2.Count);
        }

        [Fact]
        public void Should_play_game2_until_deck_empty()
        {
            var player1 = new List<int> { 9, 2, 6, 3, 1 };
            var player2 = new List<int> { 5, 8, 4, 7, 10 };
            var _crabCombat = new CrabCombat(player1, player2);
            _crabCombat.playGame2();
            Assert.Equal(10, _crabCombat.Player2.Count);
            Assert.Empty(_crabCombat.Player1);
        }

        [Fact]
        public void Should_calculate_winners_score_for_game_2()
        {
            var player1 = new List<int> { 9, 2, 6, 3, 1 };
            var player2 = new List<int> { 5, 8, 4, 7, 10 };
            var _crabCombat = new CrabCombat(player1, player2);
            _crabCombat.playGame2();
            var score = _crabCombat.calculateScore(_crabCombat.GameWinner);
            Assert.Equal(291, score);
        }
    }
}
