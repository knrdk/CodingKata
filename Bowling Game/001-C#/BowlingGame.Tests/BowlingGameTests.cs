using BowlingGame.Implementation;
using NUnit.Framework;

namespace BowlingGame.Tests
{
    public class BowlingGameTests
    {
        private const int STRIKE_SCORE = 10;
        private Game bowlingGame;

        [SetUp]
        public void SetUp()
        {
            bowlingGame = new Game();
        }

        [Test]
        public void FirstScoreShouldBeAddedToGameScore()
        {
            const int scored = 5;
            bowlingGame.Roll(scored);

            var partialScore = bowlingGame.Score;

            Assert.AreEqual(scored, partialScore);
        }

        [Test]
        public void ItShouldReturnCorrectFrameNumberForEmptyGame()
        {
            var frame = bowlingGame.Frame;

            const int expectedFrame = 1;
            Assert.AreEqual(expectedFrame, frame);
        }

        [Test]
        public void ItShouldReturnCorrectFrameNumberAfterFirstRoll_WhenWasNotStrike()
        {
            bowlingGame.Roll(1);

            var frame = bowlingGame.Frame;

            const int expectedFrame = 1;
            Assert.AreEqual(expectedFrame, frame);
        }

        [Test]
        public void ItShouldReturnCorrectFrameNumberAfterSecondRoll_WhenFirstWasNotStrike()
        {
            bowlingGame.Roll(1);
            bowlingGame.Roll(1);

            var frame = bowlingGame.Frame;

            const int expectedFrame = 2;
            Assert.AreEqual(expectedFrame, frame);
        }

        [Test]
        public void ItShouldReturnCorrectFrameNumberAfterFirstRoll_WhenWasStrike()
        {
            bowlingGame.Roll(STRIKE_SCORE);

            var frame = bowlingGame.Frame;

            const int expectedFrame = 2;
            Assert.AreEqual(expectedFrame, frame);
        }

        [Test]
        public void ItShouldEndGameAfter20NonStrikeRolls()
        {
            for (int i = 0; i < 20; i++)
            {
                bowlingGame.Roll(1);
            }

            Assert.True(bowlingGame.IsCompleted);
        }

        [Test]
        public void ItShouldNotEndGameAfterSpareInLastFrame()
        {
            for (int i = 0; i < 19; i++)
            {
                bowlingGame.Roll(1);
            }

            bowlingGame.Roll(9); // spare

            Assert.False(bowlingGame.IsCompleted);
        }

        [Test]
        public void ItShouldNotEndGameInTenthFrameAfterTwoStrikes()
        {
            for (int i = 0; i < 18; i++)
            {
                bowlingGame.Roll(1);
            }
            bowlingGame.Roll(STRIKE_SCORE);
            bowlingGame.Roll(STRIKE_SCORE);

            Assert.False(bowlingGame.IsCompleted);
        }

        [Test]
        public void ItShouldEndGameInTenthFrameAfterNonSpare()
        {
            for (int i = 0; i < 18; i++)
            {
                bowlingGame.Roll(1);
            }
            bowlingGame.Roll(5);
            bowlingGame.Roll(4);

            Assert.True(bowlingGame.IsCompleted);
        }

        [TestCase(1)]
        [TestCase(10)]
        public void ItShouldEndGameInTenthFrameAfterThirdRoll(int scoreInThirdRoll)
        {
            for (int i = 0; i < 18; i++)
            {
                bowlingGame.Roll(1);
            }
            bowlingGame.Roll(5);
            bowlingGame.Roll(5); // spare

            bowlingGame.Roll(scoreInThirdRoll);

            Assert.True(bowlingGame.IsCompleted);
        }

        [Test]
        public void ItShouldCalculateCorrectScoreAfterSpareInFirstRoll()
        {
            bowlingGame.Roll(4);
            bowlingGame.Roll(6); // spare

            bowlingGame.Roll(5);
            bowlingGame.Roll(3);

            Assert.AreEqual(23, bowlingGame.Score); // Frame1: 15, Frame2: 5
        }

        [Test]
        public void ItShouldCalculateCorrectScoreAfterStrikeInFirstRoll()
        {
            bowlingGame.Roll(STRIKE_SCORE);

            bowlingGame.Roll(5);
            bowlingGame.Roll(3);

            Assert.AreEqual(26, bowlingGame.Score); // Frame1: 18, Frame2: 8
        }

        [Test]
        public void ItShouldCalcualateCorrectScoreAfterWholeGame()
        {
            int[] scores = { 1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 2, 8, 6 };
            foreach(var score in scores){
                bowlingGame.Roll(score);
            }

            Assert.AreEqual(133, bowlingGame.Score);
        }
    }
}