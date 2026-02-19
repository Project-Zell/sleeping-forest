using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Test : MonoBehaviour
{
    public class ProjectileWeaponBase : MonoBehaviour
    {
        [SerializeField] private Test.ProjectileBase projectilePrefab;

        public Dictionary<StatType, WeaponStat> stats = new();

        public void Fire()
        {
            var projctileInstance = Instantiate(projectilePrefab);
            projctileInstance.Initialize();


        }
    }

    public class ProjectileBase : MonoBehaviour
    {
        public int AttackPower;
        public int MovementSpeed;

        public void Initialize()
        {

        }
    }

    public class WeaponStats
    {
        public Dictionary<StatType, WeaponStat> stats = new();

    }

    public class WeaponBasicStatsSO : ScriptableObject
    {
        public Dictionary<WeaponStatType, WeaponStat> stats = new();

        public void OnValidate()
        {
            var currentWeaponStatsEntrys = WeaponStatType.GetAll();

            foreach (var weaponType in currentWeaponStatsEntrys)
            {
                stats.TryAdd(weaponType, new WeaponStat(default, default));
            }
        }
    }

    public class WeaponStatStarter
    {
        public WeaponStatType WeaponStatType;
        public int Value;


    }

    public class WeaponStatistics
    {
        public Dictionary<WeaponStatType, WeaponStat> stats = new();


        public WeaponStat GetStat(WeaponStatType weaponStatType)
        {
            return stats[weaponStatType];
        }
    }

    public class WeaponStatType
    {
        public readonly static WeaponStatType Damage = new("Damage");
        public readonly static WeaponStatType Area = new("Area");
        public readonly static WeaponStatType CriticalHit = new("CriticalHitChance");
        public readonly static WeaponStatType CriticalDamage = new("CriticalHitDamage");
        public readonly static WeaponStatType ProjectileSpeed = new("ProjectileSpeed");
        public readonly static WeaponStatType ProjectileCount = new("ProjectileCount");
        public readonly static WeaponStatType ChanceToStatusOnHit = new("ChanceToStatusOnHit");
        public readonly static WeaponStatType ArmorPenetration = new("ArmorPenetration");


        public readonly string Key;
        private WeaponStatType(string key)
        {
            Key = key;
        }

        public static WeaponStatType[] GetAll() => new WeaponStatType[] {  };
    }



    ///Player
    /*
     * Damage
     * Critical Hit Chance
     * Critical Hit Damage
     * Cast Speed
     * Area 
     * Health
     * Armor
     * Movement Speed
     */

    ///Weapon
    /*
     * Damage
     * Area
     * Cast Speed
     * Critical Hit Chance
     * Ciritcal Hit Damage
     * Projectile Speed
     * Projectile Count
     * Chance To Status On Hit
     * Armor Penetration
     */
}
