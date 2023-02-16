namespace Infrastructure.DI.Services.Generator
{
    public class LevelXpGenerator : ILevelXpGenerator
    {
        public int GenerateNextLevelXp(int currentLevel)
        {
            // todo: Переделать формулу
            return currentLevel * 10 + 15;
        }
    }
}