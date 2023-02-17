namespace Infrastructure.DI.Services.Generator
{
    public class LevelXpGenerator : ILevelXpGenerator
    {
        private const float CoefficientA = 100;
        private const float CoefficientB = 0.1f;
        
        public int GenerateNextLevelXp(int currentLevel)
        {
            if (currentLevel == 1)
            {
                return (int)CoefficientA;
            }
            return (int)(CoefficientA * (currentLevel - 1) + CoefficientA * (currentLevel - 1) * CoefficientB);
        }
    }
}