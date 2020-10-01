﻿using System;

namespace RandomNumberGame.Models
{
    public class Game
    {
        public Difficulty Difficulty { get; set; }
        public int GuessesLeft { get; set; }
        public string CurrentMessage { get; set; }
        public bool Complete { get; set; }
        
        private int _randomNumber;

        public Game(Enums.DifficultyLevel difficultyLevel) : this(Factory.GetDifficulty(difficultyLevel)) { }
        public Game(Difficulty difficulty)
        {
            Difficulty = difficulty;

            GuessesLeft = difficulty.AllowedGuesses;

            Random rnd = new Random();
            _randomNumber = rnd.Next(Difficulty.LowerLimit, Difficulty.UpperLimit);
        }

        public void MakeGuess(int guess)
        {
            GuessesLeft--;

            if (_randomNumber == guess)
            {
                CurrentMessage = $"Congratulations! You got it right with {GuessesLeft}!";
                Complete = true;
            }
            else
            {
                if (_randomNumber > guess)
                {
                    CurrentMessage = $"Too low! Try again!";
                }
                else
                {
                    CurrentMessage = "Too high! Try again!";
                }

                if (GuessesLeft <= 0)
                {
                    CurrentMessage = "You are out of guesses, better luck next time!";
                    Complete = true;
                }
            }
        }
    }
}