namespace RandomNumberGame.Models
{
    public class Easy : Difficulty
    {
        public Easy()
        {
            Name = "Easy";
            AllowedGuesses = 10;
            LowerLimit = 1;
            UpperLimit = 10;
        }
    }
}