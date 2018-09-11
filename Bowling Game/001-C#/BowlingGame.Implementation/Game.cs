using System.Collections.Generic;
using System.Linq;

namespace BowlingGame.Implementation
{
    public class Game
    {
        private const int NUMBER_OF_FRAMES = 10;
        private List<IFrame> _frames;
        private IFrame _currentFrame => _frames.Last();

        public int Score => CalculateScore();

        public int Frame => _frames.Count;
        public bool IsCompleted => Frame == NUMBER_OF_FRAMES && _currentFrame.IsCompleted;

        public Game()
        {
            _frames = new List<IFrame>(NUMBER_OF_FRAMES);
            _frames.Add(new Frame());
        }

        public void Roll(int score)
        {
            if (IsCompleted)
            {
                return;
            }

            _currentFrame.Roll(score);

            if (_currentFrame.IsCompleted)
            {
                CreateNewFrame();
            }
        }

        private void CreateNewFrame()
        {
            const int LAST_BUT_ONE_FRAME_NUMBER = NUMBER_OF_FRAMES - 1;
            IFrame frameToInsert = null;
            if (Frame < LAST_BUT_ONE_FRAME_NUMBER)
            {
                frameToInsert = new Frame();
            }
            else if (Frame == LAST_BUT_ONE_FRAME_NUMBER)
            {
                frameToInsert = new LastFrame();
            }

            if (frameToInsert != null)
            {
                _currentFrame.NextFrame = frameToInsert;
                _frames.Add(frameToInsert);
            }
        }

        private int CalculateScore()
        {
            return _frames.Sum(x => x.Score);
        }
    }
}