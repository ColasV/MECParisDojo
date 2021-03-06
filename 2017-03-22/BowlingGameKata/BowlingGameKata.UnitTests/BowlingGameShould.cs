﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata.UnitTests
{
    [TestClass]
    public class BowlingGameShould
    {
        [TestMethod]
        public void StartWithScoreOfZero()
        {
            int score = new BowlingGame().Score();
            Assert.AreEqual(0, score);
        }

        [TestMethod]
        public void UpdateScore()
        {
            var bowlingGame = new BowlingGame();
            for (int i = 0; i < 3; ++i)
            {
                bowlingGame.Roll(1);
            }
            Assert.AreEqual(3, bowlingGame.Score());
        }

        [TestMethod]
        public void RecordFirstRoll()
        {
            BowlingGame bowlingGame = new BowlingGame();
            bowlingGame.Roll(5);
            int score = bowlingGame.Score();
            Assert.AreEqual(5, score);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RollThrowOnOutOfRangePin()
        {
            new BowlingGame().Roll(11);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RollThrowOnNegativePin()
        {
            new BowlingGame().Roll(-1);
        }

        [TestMethod]
        public void GetCurrentFrame()
        {
            BowlingGame bowlingGame = new BowlingGame();
            Frame frame = bowlingGame.CurrentFrame;
            Assert.IsNotNull(frame);
        }

        [TestMethod]
        public void VerifySeveralRollsCreateSeveralFrames()
        {
            var bowlingGame = new BowlingGame();
            bowlingGame.Roll(1);
            bowlingGame.Roll(2);
            bowlingGame.Roll(3);
            Assert.AreEqual(2, bowlingGame.Round);
        }

        [TestMethod]
        public void EndGameAfterLastRound()
        {
            var bowlingGame = new BowlingGame();
            for(int i = 0; i < 20; ++i)
            {
                bowlingGame.Roll(2);
            }

            Assert.IsTrue(bowlingGame.IsFinished);
            Assert.AreEqual(40, bowlingGame.Score());
        }
    }
}
