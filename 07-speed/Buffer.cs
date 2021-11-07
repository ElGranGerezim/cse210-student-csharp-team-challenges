using System;

namespace _07_speed
{
    class Buffer : Actor
    {
        public Buffer(){
            _position = new Point(0, Constants.MAX_Y - 50);
            _width = Constants.MAX_X;
        }
        
        // Empties the text field for the next word.
        public void reset()
        {
            _text = "";
        }

        // Returns the comparison of the input with the word.
        public bool compare(string word)
        {
            return _text.Contains(word);
        }

        // Update the text with the user input.
        public void updateBuffer(string input)
        {
            _text += input;
        }
    }

    
}
