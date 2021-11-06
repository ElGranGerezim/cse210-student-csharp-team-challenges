using System;
using System.Collections.Generic;


namespace _07_speed
{
    class Director
    {
        Scoreboard _scoreBoard = new Scoreboard();
        

        Scoreboard _lifeBoard = new Scoreboard();


        Difficulty _difficultyManager = new Difficulty();

        
        List<Enemies> _enemiesList = new List<Enemies>{};


        Buffer _buffer = new Buffer();


        InputService _inputService = new InputService();


        OutputService _outputService = new OutputService();   

        int _kills = 0;

        bool _playing = true;        

        /// <summary>
        /// This method starts the game and continues running until it is finished.
        /// </summary>
        public void StartGame()
        {
            PrepareGame();

            while (_playing)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }

            Console.WriteLine("Game over!");
        }

        private void PrepareGame()
        {
            _outputService.OpenWindow(Constants.MAX_Y, Constants.MAX_X, "Speed Game", Constants.FRAME_RATE);
        }

        private void GetInputs()
        {
            string letter = _inputService.getInput();

            if (letter != "")
            {
                _buffer.updateBuffer(letter);
            }
        }

        private void DoUpdates()
        {
            moveEnemies();
            handleBufferVsEnemy();
            handleEscapedEnemies();
            _difficultyManager.updateDifficulty(_kills);
            spawnEnemies();

        }

        private void DoOutputs()
        {
            _outputService.StartDrawing();

            _outputService.DrawActor(_scoreBoard);
            _outputService.DrawActor(_lifeBoard);

            _outputService.DrawActor(_buffer);
            foreach (Enemies word in _enemiesList)
            {
                _outputService.DrawActor(word);   
            }

            _outputService.EndDrawing();
            
        }

        private int getLane()
        {
            Random rand = new Random();

            int laneWidth = Constants.MAX_Y/_difficultyManager.getMaxEnemies();
            int lane = rand.Next(0, _difficultyManager.getMaxEnemies());
            int spawnPosition = (lane * laneWidth) + 10;  

            return spawnPosition;
        }

        private void handleBufferVsEnemy()
        {
            List<Enemies> wordsToRemove = new List<Enemies>();

            foreach (Enemies word in _enemiesList)
            {
                if (_buffer.compare(word.GetText()))
                {
                    wordsToRemove.Add(word);
                    _buffer.reset();
                }
            }
            foreach (Enemies word in wordsToRemove)
            {
                _kills ++;
                _scoreBoard.AddPoints(word.getPoint());
                _enemiesList.Remove(word);
            }
        }
        private void handleEscapedEnemies()
        {
            List<Enemies> wordsToRemove = new List<Enemies>();

            foreach (Enemies word in _enemiesList)
            {
                if (word.hasEscaped())
                {
                    wordsToRemove.Add(word);
                }
            }
            foreach (Enemies word in wordsToRemove)
            {
                _lifeBoard.AddPoints(-word.getPoint());
                _enemiesList.Remove(word);
            }
        }
        private void spawnEnemies()
        {
            while (_enemiesList.Count< _difficultyManager.getMaxEnemies())
            {
                Enemies enenmyspawn = new Enemies(_difficultyManager.getSpeed(), getLane());
            }
        }

        private void moveEnemies()
        {
            foreach (Enemies word in _enemiesList)
            {
                word.MoveNext();
            }
        }

        private bool gameOver()
        {
            if (_lifeBoard.GetPoints() <= 0)
            {
                _playing = false;
            }
            else 
            {
                _playing = true;
            }
            return _playing;
        }


    }
}
