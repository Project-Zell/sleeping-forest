using Coollel.Luca;
using UnityEngine;

public class StrikeBase : WeaponBase
{
    protected Vector3 velocity;

    public float timeNow;

    public float damageMod = 1;

    public LayerMask enemyLayer;

    // Called after instantiation
    public virtual void Initialize(SkillSO skillValues, Vector3 shootDirection)
    {
        //if (skillValues != null)
        //{
        //    damage = skillValues.damage;
        //    damageOverTime = skillValues.damageOverTime;
        //    armorReduction = skillValues.armorReduction;
        //    movementSpeedReduction = skillValues.movementSpeedReduction;
        //    speed = skillValues.speed;
        //    Cooldown = skillValues.cooldown;
        //    lifetime = skillValues.lifetime;
        //    isActive = skillValues.isActive;
        //    SkillName = skillValues.skillName;
        //    attackRadius = skillValues.attackRadius;
        //    attackAngle = skillValues.attackAngle;
        //    strikeOffset = skillValues.spawnOffset;

        //}
        //else
        //{
        //    Debug.LogWarning("Strike Skill values not assigned!");
        //}

        //Activate();
        base.Initialize(skillValues);
        transform.position = skillValues.spawnOffset;
    }

    protected virtual void Update()
    {

    }

    public virtual void OnTriggerEnter(Collider other)
    {
        // Damage and destroy logic
        //gameObject.SetActive(false);
    }

    public void upgradeDamage(float increase)
    {
        //0.2

        damageMod += increase;
    }

    public float doDamage()
    {
        return Damage *= damageMod;
    }
}
