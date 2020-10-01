using System;

namespace RandomNumberGame.Models
{
    public static class Factory
    {
        public static Difficulty GetDifficulty(Enums.DifficultyLevel difficultyLevel)
        {
            switch (difficultyLevel)
            {
                case Enums.DifficultyLevel.Easy: return new Easy();
                case Enums.DifficultyLevel.Hard: return new Hard();
                case Enums.DifficultyLevel.Medium: return new Medium();
                case Enums.DifficultyLevel.Impossible: return new Impossible();
                default:
                    throw new Exception($"Unfortunately, we cannot find the difficulty matching the selection {difficultyLevel.ToString()}");
            }
        }
    }
}