namespace RandomNumberGame.Models
{
    public class Medium : Difficulty
    {
        public Medium()
        {
            Name = "Medium";
            AllowedGuesses = 10;
            LowerLimit = 1;
            UpperLimit = 100;
        }
    }
}