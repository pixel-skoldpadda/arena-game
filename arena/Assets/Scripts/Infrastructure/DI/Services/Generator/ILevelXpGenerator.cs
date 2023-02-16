namespace Infrastructure.DI.Services.Generator
{
    public interface ILevelXpGenerator : IService
    {
        int GenerateNextLevelXp(int currentLevel);
    }
}