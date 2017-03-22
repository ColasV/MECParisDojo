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
        public void ReturnScore()
        {
            int score = new BowlingGame().Score();
            Assert.AreEqual(0, score);
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
            Frame frame = bowlingGame.CurrentFrame();
            frame.Roll(5);
            Assert.AreEqual(5, frame.FrameScore());
        }
    }
}
