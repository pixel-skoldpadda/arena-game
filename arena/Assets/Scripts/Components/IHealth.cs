namespace Components
{
    public interface IHealth
    {
        float MaxHp { set; }
        void TakeDamage(int damage);
    }
}