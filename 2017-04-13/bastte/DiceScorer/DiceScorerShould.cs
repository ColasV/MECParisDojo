﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DiceScorer
{
    public class DiceScorerShould
    {
        [Theory]
        [InlineData(0, new int[] { 3 })]
        [InlineData(100, new int[] { 1 })]
        [InlineData(50, new int[] { 5 })]
        [InlineData(150, new int[] { 1, 5 })]
        [InlineData(150, new int[] { 1, 2, 3, 5 })]
        [InlineData(1000, new int[] { 1, 1, 1 })]
        [InlineData(1050, new int[] { 1, 1, 1, 5 })]
        [InlineData(600, new int[] { 6, 6, 6 })]
        [InlineData(1200, new int[] { 6, 6, 6, 6 })]
        [InlineData(2000, new int[] { 1, 1, 1, 1 })]
        [InlineData(800, new int[] { 1, 1, 2, 2, 3, 3 })]
        [InlineData(800, new int[] { 1, 2, 3, 3, 2, 1 })]
        public void CorrectlyScore(int expectedScore, int[] dice)
        {
            var scorer = new DiceScorer();
            int score = scorer.Score(dice.ToList());
            Assert.Equal(expectedScore, score);
        }
    }
}