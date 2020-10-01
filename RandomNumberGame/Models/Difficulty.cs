namespace RandomNumberGame.Models
{
    public class Difficulty
    {
        public string Name { get; set; }
        public int LowerLimit { get; set; }
        public int UpperLimit { get; set; }
        public int AllowedGuesses { get; set; }
    }
}