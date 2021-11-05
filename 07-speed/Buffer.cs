using System;

namespace _07_speed
{
    class Buffer : Actor
    {
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
