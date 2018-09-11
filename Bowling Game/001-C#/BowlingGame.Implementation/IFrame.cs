namespace BowlingGame.Implementation
{
    internal interface IFrame
    {
        bool IsCompleted { get; }
        int Score { get; }
        void Roll(int score);
        IFrame NextFrame { get; set; }
        int FirstRollScore { get; }
        int NextTwoRollsScore { get; }
    }
}