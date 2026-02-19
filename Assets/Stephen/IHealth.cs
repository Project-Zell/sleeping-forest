using System;
using UnityEngine.Events;

public interface IHealth
{
    public int CurrentHealth { get; }
    public int MaxHealth { get; }
    public void TakeDamage(float damage);

    public UnityEvent OnDeath { get; }
}
