using System;

namespace _07_speed
{
    ///<summary>The difficulty class helps increase the difficulty of the game as 
    ///the player guesses words correctly. This class determines the speed of newly generated words
    /// and how many words there should be.</summary>
    class Difficulty
    {
        private int _maxEnemies = 5;
        

        private int _speed = 2;

        const int _gapBetweenPhases = 10;

        /// <summary>Do the logic to determine what the new difficulty of the game should be
        /// based on how many kills have happened so far.</summary>
        ///<param name="kills"><param>
        ///<return>none<return>
        public void updateDifficulty(int kills)
        {
            // Hardest phase, Phase 4
            if (kills >= (_gapBetweenPhases * 4))
            {
                _maxEnemies = 10;
                _speed = 4;
            }
            
            // intermediate phase 3
            else if (kills >= (_gapBetweenPhases * 3))
            {
                _maxEnemies = 8;
                _speed = 3;
            }

            // intermediate phase 2
            else if (kills >= (_gapBetweenPhases * 2))
            {
                _maxEnemies = 7;
                _speed = 2;
            }

            // Phase 1 with a slow introduction of words
            else if (kills <= (_gapBetweenPhases))
            {
                if (kills >= Math.Round(_gapBetweenPhases * .8))
                {
                    _maxEnemies = 5;
                    _speed = 1;
                }

                else if (kills >= Math.Round(_gapBetweenPhases * .6))
                {
                    _maxEnemies = 4;
                    _speed = 1;
                }

                else if (kills >= Math.Round(_gapBetweenPhases * .4))
                {
                    _maxEnemies = 3;
                    _speed = 1;
                }

                else if (kills >= Math.Round(_gapBetweenPhases * .2))
                {
                    _maxEnemies = 2;
                    _speed = 1;
                }

                else
                {
                    _maxEnemies = 1;
                    _speed = 1;
                }

            }

            

            
        }

        /// <summary>get the speed value for newly generated words</summary>
        ///<return>int _speed<return>
        public int getSpeed()
        {
            return _speed;
        }

        /// <summary>get the value for how many enemies there should be</summary>
        ///<return>int _maxEnemies<return>
        public int getMaxEnemies()
        {
            return _maxEnemies;
        }

    }
}
