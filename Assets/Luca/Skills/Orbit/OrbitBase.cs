using Coollel.Luca;
using UnityEngine;

public class OrbitBase : WeaponBase
{
    [Header("Orbit Stats")]
    //public float damage;
    //public float damageOverTime;
    //public float armorReduction;
    //public float movementSpeedReduction;
    //public float speed;
    //public float Cooldown;
    //public float lifetime;
    //public string SkillName;
    //public float radius;
    //public Vector3 spawnOffset;

    public float startAngle = 0f;

    public bool isActive;

    public float timeNow;

    public float damageMod = 1;

    //public Vector3 scale;

    // Called after instantiation
    //public virtual void Initialize(SkillSO skillValues)
    //{
    //    if (skillValues != null)
    //    {
    //        damage = skillValues.damage;
    //        damageOverTime = skillValues.damageOverTime;
    //        armorReduction = skillValues.armorReduction;
    //        movementSpeedReduction = skillValues.movementSpeedReduction;
    //        speed = skillValues.speed;
    //        Cooldown = skillValues.cooldown + skillValues.lifetime;
    //        lifetime = skillValues.lifetime;
    //        isActive = skillValues.isActive;
    //        SkillName = skillValues.skillName;
    //        radius = skillValues.radius;
    //        scale = skillValues.scale;
    //        spawnOffset = skillValues.spawnOffset;
    //    }
    //    else
    //    {
    //        Debug.LogWarning("ProjectileSkill values not assigned!");
    //    }
    //    Activate();
    //}

    public void upgradeDamage(float increase)
    {
        //0.2

        damageMod += increase;
    }

    public float doDamage()
    {
        return Damage *= damageMod;
    }

    public void setRadius(float newRadius)
    {
        Radius = newRadius;
    }

    public void setSpeed(float newSpeed)
    {
        Speed = newSpeed;
    }

    public void setCooldown(float newCooldown)
    {
        Cooldown = newCooldown;
    }

    public void setLifetime(float newLifetime)
    {
        Lifetime = newLifetime;
    }

    public void setSize(Vector3 newScale)
    {
        Scale = newScale;
    }

    protected virtual void Update()
    {
        //Debug.Log(this.transform.forward);
        Move();
    }

    public virtual void Move()
    {

    }

    public virtual void OnTriggerEnter(Collider other)
    {
        // Damage and destroy logic
        if (other.CompareTag("Enemy"))
        {
            if (other.TryGetComponent(out IHealth health))
            {
                health.TakeDamage(doDamage());
            }
        }
        //Destroy(gameObject);
        //gameObject.SetActive(false);
    }

    public void Orbit(Transform target, float orbitSpeed, float radius)
    {
        if (target == null) return;

        // Get the player's Y rotation in radians
        //float playerYAngle = target.eulerAngles.y * Mathf.Deg2Rad;

        // Calculate the orbit angle, subtracting the player's rotation
        float startAngleRadians = startAngle * Mathf.Deg2Rad;
        float angle = startAngleRadians + Time.time * orbitSpeed;

        Vector3 offset = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * radius;
        transform.position = target.position + offset;
    }
}