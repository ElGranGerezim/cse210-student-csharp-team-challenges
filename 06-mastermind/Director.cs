using System;
using System.Collections.Generic;

namespace _06_mastermind
{
    class Director
    {
        Board _board;

        Code _code;

        UserService _userService;

      
        bool _keepPlaying = true;

        /// <summary>Get the guess needed for the game</summary>
        ///<params>none</params>
        ///<returns>string guess</returns>
        private string getInputs()
        {
            string guess = _userService.getGuess();

            return guess;
        }

        /// <summary>update the player and get the hint</summary>
        ///<params>string guess - gotten from the input</params>
        ///<returns>none</returns>
        private void doUpdates(string guess)
        {
            
            string hint = _code.getHint(guess);
            if (_code.isSecret(guess))
            {
                _keepPlaying = false;
                _board.updatePlayer(guess, hint, false);
            } else {
                _board.updatePlayer(guess, hint);
            }
        }

        /// <summary>Display the board to the console</summary>
        ///<params>none</params>
        ///<returns>none</returns>
        private void doOutput()
        {
            _userService.displayTurn(_board.formatTurnDisplay());
        }
        
        /// <summary>initialize all of the member variables for a fresh game</summary>
        ///<params>none</params>
        ///<returns>none</returns>
        private void startGame()
        {
            _userService = new UserService();
            _code = new Code();
            _board = new Board();
            List<string> names = _userService.getName();
            _board.namePlayers(names);
            
        }

        /// <summary>the main loop of the game that calls the other game related methods </summary>
        ///<params>none</params>
        ///<returns>none</returns>
        public void playGame()
        {
            startGame();
            while(_keepPlaying)
            {
                doOutput();
                string guess = getInputs();
                doUpdates(guess);
            }
            EndGame();

        
        }

        ///<summary>Display the message at the end saying who has won the game </summary>
        ///<params> none </params>
        ///<returns> none </returns>
        private void EndGame()
        {
            _userService.displayTurn(_board.formatTurnDisplay(true));
        }
    }
}