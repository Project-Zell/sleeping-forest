using UnityEngine;

[System.Serializable]
public class WeaponBaseStats
{
    [field: SerializeField] public string WeaponName { get; private set; }
    [field: SerializeField] public float BaseDamage { get; private set; }
    [field: SerializeField] public float BaseCooldown { get; private set; }
    [field: SerializeField] public float BaseSpeed { get; private set; }
    [field: SerializeField] public float BaseLifespawn { get; private set; }
}

public class WeaponStats
{
    [field: SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public float Cooldown { get; private set; }
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float Lifespawn { get; private set; }

    public WeaponStats(CharacterStats playerStats, WeaponBaseStats weaponBaseStats)
    {
        Damage = playerStats.GetStat(StatType.AttackPower).CurrentValue + weaponBaseStats.BaseDamage;
        Cooldown = weaponBaseStats.BaseCooldown;
        Speed = weaponBaseStats.BaseSpeed;
        Lifespawn = weaponBaseStats.BaseLifespawn;
    }
}

public interface IWeapon
{
    public WeaponBaseStats WeaponStats { get; }
}

public abstract class ProjectileComponent : IWeapon
{
    public WeaponBaseStats WeaponStats => _weaponStats;

    private WeaponBaseStats _weaponStats;
}