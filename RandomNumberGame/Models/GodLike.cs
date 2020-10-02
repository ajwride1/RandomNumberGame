namespace RandomNumberGame.Models
{
    public class GodLike : Difficulty
    {
        public GodLike()
        {
            Name = "GodLike";
            AllowedGuesses = 2;
            LowerLimit = 1;
            UpperLimit = 10000;
        }
    }
}