using System;
using System.IO;
using System.Collections.Generic;
using Raylib_cs;

namespace _07_speed
{
    /// <summary> Class to contain all info about enemies
    class Enemies : Actor
    {
        private int _points;

        /// <summary> Constructor to generate new enemy. 
        /// <params> Speed: how fast the enemy moves
        /// <params> Height: How high on the screen to spawn enemy
        public Enemies(int speed, int height)
        {
            _position = new Point(Constants.MAX_X, height);
            SetVelocity(new Point(speed, 0));
            SelectWord();
            _points = _text.Length;
            _width = _points * Constants.DEFAULT_FONT_SIZE;
        }

        /// <summary> Selects a word at random from a txt file and changes the _text member variable.
        public void SelectWord()
        {
            List<string> lines = new List<string>(File.ReadAllLines("WordList.txt"));
            Random r = new Random();
            int randomLineNumber = r.Next(0, lines.Count - 1);
            string word = lines[randomLineNumber];

            _text = word;
        }

        /// <summary> Returns the point value of the enemy
        /// <returns> Int: _points
        public int getPoint(){
            return _points;
        }

        /// <summary> Returns whether or not the enemy has escaped
        /// <returns> Bool: escaped
        public bool hasEscaped(){
            return (_position.GetX() <= 0);
        }

    }
}
