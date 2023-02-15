using System;

namespace Components
{
    public interface IHealth
    {
        event Action HealthChanged;
        float Current { get; }
        float MaxHp { set; }
        void TakeDamage(int damage);
    }
}