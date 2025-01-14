using System;

namespace _07_speed
{
    class Scoreboard : Actor
    {
        private int _points = 0;

        private bool isLifeBoard = false;

        public Scoreboard(bool life)
        {
            isLifeBoard = life;
            _position = new Point(1, 0); 
            if (isLifeBoard){
                _position = new Point(1, 50);
                _points = 100;
            }
            _width = 0;
            _height = 0;
            
            UpdateText();
        }

        /// <summary>
        /// Increments the points by the amount specified and updates the
        /// text.
        /// </summary>
        /// <param name="points"></param>
        public void AddPoints(int points)
        {
            _points += points;
            UpdateText();
        }

        /// <summary> Gets the point value currently stored in _points
        /// <returns> Int: _points
        public int GetPoints(){
            return _points;
        }

        /// <summary>
        /// Updates the text to reflect the new points amount.
        /// This should be called whenever the points are updated.
        /// </summary>
        private void UpdateText()
        {
            if (isLifeBoard){
                _text = $"Lives: {_points}";
            } else {
                _text = $"Score: {_points}";
            }
        }
    }
}
