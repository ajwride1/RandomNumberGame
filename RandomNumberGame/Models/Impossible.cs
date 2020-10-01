namespace RandomNumberGame.Models
{
    public class Impossible : Difficulty
    {
        public Impossible()
        {
            Name = "Impossible";
            AllowedGuesses = 1;
            LowerLimit = 1;
            UpperLimit = 1000000;
        }
    }
}