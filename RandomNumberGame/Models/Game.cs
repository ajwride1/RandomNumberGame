using System;

namespace RandomNumberGame.Models
{
    public class Game
    {
        public Difficulty Difficulty { get; set; }
        public int GuessesLeft { get; set; }
        public string CurrentMessage { get; set; }
        public bool Complete { get; set; }
        public bool Success { get; set; }
        public bool Failure { get; set; }
        
        private int _randomNumber;

        public Game(Enums.DifficultyLevel difficultyLevel) : this(Factory.GetDifficulty(difficultyLevel)) { }
        public Game(Difficulty difficulty)
        {
            Difficulty = difficulty;

            GuessesLeft = difficulty.AllowedGuesses;

            Random rnd = new Random();
            _randomNumber = rnd.Next(Difficulty.LowerLimit, Difficulty.UpperLimit);

            CurrentMessage = $"Start by making a guess between {Difficulty.LowerLimit} and {Difficulty.UpperLimit}";
        }

        public void MakeGuess(int guess)
        {
            if (guess > Difficulty.UpperLimit)
            {
                CurrentMessage =
                    $"Your guess {guess} is too high for the upper limit of {Difficulty.UpperLimit}, please try again with a guess between {Difficulty.LowerLimit} and {Difficulty.UpperLimit}";
            }
            else if (guess < Difficulty.LowerLimit)
            {
                CurrentMessage =
                    $"Your guess {guess} is too low for the lower limit of {Difficulty.LowerLimit}, please try again with a guess between {Difficulty.LowerLimit} and {Difficulty.UpperLimit}";
            }
            else
            {
                GuessesLeft--;

                if (_randomNumber == guess)
                {
                    if (GuessesLeft == 1)
                    {
                        CurrentMessage = $"Congratulations! You got it right with {GuessesLeft} guess left!";
                    }
                    else
                    {
                        CurrentMessage = $"Congratulations! You got it right with {GuessesLeft} guesses left!";
                    }

                    Complete = true;
                    _successful();
                }
                else
                {
                    if (_randomNumber > guess)
                    {
                        CurrentMessage = $"Too low! Try again!";
                        _failed();
                    }
                    else
                    {
                        CurrentMessage = "Too high! Try again!";
                        _failed();
                    }

                    if (GuessesLeft <= 0)
                    {
                        CurrentMessage =
                            $"You are out of guesses, better luck next time! The correct number was {_randomNumber}";
                        Complete = true;
                        _failed();
                    }
                }
            }
        }

        private void _failed()
        {
            Success = false;
            Failure = true;
        }

        private void _successful()
        {
            Success = true;
            Failure = false;
        }
    }
}