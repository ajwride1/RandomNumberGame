namespace RandomNumberGame.Models
{
    public class Hard : Difficulty
    {
        public Hard()
        {
            Name = "Hard";
            AllowedGuesses = 5;
            LowerLimit = 1;
            UpperLimit = 100;
        }
    }
}