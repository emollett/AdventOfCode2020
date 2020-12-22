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
            _crabCombat.playRound();
            Assert.Equal(2, _crabCombat.Player1.Count);
            Assert.Empty(_crabCombat.Player2);
        }

        [Fact]
        public void Should_play_until_deck_empty()
        {
            var player1 = new List<int> { 9, 2, 6, 3, 1 };
            var player2 = new List<int> { 5, 8, 4, 7, 10 };
            var _crabCombat = new CrabCombat(player1, player2);
            _crabCombat.playGame();
            Assert.Equal(10, _crabCombat.Player2.Count);
            Assert.Empty(_crabCombat.Player1);
        }

        [Fact]
        public void Should_calculate_winners_score()
        {
            var player1 = new List<int> { 9, 2, 6, 3, 1 };
            var player2 = new List<int> { 5, 8, 4, 7, 10 };
            var _crabCombat = new CrabCombat(player1, player2);
            _crabCombat.calculateScore();
            Assert.Equal(306, _crabCombat.WinningScore);
        }
    }
}
