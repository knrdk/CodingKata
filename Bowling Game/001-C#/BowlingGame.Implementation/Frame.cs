using System;

namespace BowlingGame.Implementation
{
    internal class Frame : IFrame
    {
        private const int MAX_SCORE = 10;

        public int? FirstScore { get; private set; }
        public int? SecondScore { get; private set; }
        public bool IsCompleted => IsStrike() || SecondScore.HasValue;
        public int Score => CalculateScore();
        public IFrame NextFrame { get; set; }

        public int FirstRollScore => FirstScore ?? 0;

        public int NextTwoRollsScore => CalculateNextTwoRollsScore();

        public void Roll(int score)
        {
            if (IsCompleted)
            {
                return;
            }

            if (!FirstScore.HasValue)
            {
                FirstScore = score;
            }
            else
            {
                SecondScore = score;
            }
        }
        private int CalculateScore()
        {
            int score = (FirstScore ?? 0) + (SecondScore ?? 0);
            if (IsStrike())
            {
                score += NextFrame.NextTwoRollsScore;
            }
            else if (IsSpare(score))
            {
                score += NextFrame.FirstRollScore;
            }
            return score;
        }

        private int CalculateNextTwoRollsScore()
        {
            if (IsStrike())
            {
                return (FirstScore ?? 0) + (NextFrame?.FirstRollScore ?? 0);
            }
            else
            {
                return (FirstScore ?? 0) + (SecondScore ?? 0);
            }
        }

        private bool IsSpare(int ownScore)
        {
            return ownScore == MAX_SCORE;
        }

        private bool IsStrike()
        {
            return FirstScore == MAX_SCORE;
        }
    }
}