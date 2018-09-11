namespace BowlingGame.Implementation
{
    internal sealed class LastFrame : IFrame
    {
        public int? FirstScore { get; private set; }
        public int? SecondScore { get; private set; }
        public int? ThirdScore { get; private set; }
        public IFrame NextFrame { get; set; }
        public bool IsCompleted => ThirdScore.HasValue || (SecondScore.HasValue && Score < 10);
        public int Score => (FirstScore ?? 0) + (SecondScore ?? 0) + (ThirdScore ?? 0);

        public int FirstRollScore => FirstScore ?? 0;

        public int NextTwoRollsScore => FirstRollScore + (SecondScore ?? 0);

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
            else if (!SecondScore.HasValue)
            {
                SecondScore = score;
            }
            else
            {
                ThirdScore = score;
            }
        }

        public bool IsStrike()
        {
            return FirstScore == 10;
        }

        public bool IsSpare()
        {
            return Score == 10;
        }
    }
}