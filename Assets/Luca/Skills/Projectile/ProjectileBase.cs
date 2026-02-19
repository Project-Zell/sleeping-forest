using Coollel.Luca;
using UnityEngine;

public abstract class ProjectileBase : WeaponBase
{
    public bool isActive;
    protected Vector3 velocity;

    public Transform FirePoint;

    public float timeNow;

    public float damageMod = 1;

    public bool IsInitialized = false;

    public void SetVelocity(Vector3 shootDirection)
    {
        velocity = shootDirection.normalized * Speed;
        Activate();
    }

    public void upgradeDamage(float increase)
    {
        damageMod += increase;
    }

    public float doDamage()
    {
        return Damage *= damageMod;
    }

    protected virtual void Update()
    {
        Move();
    }

    public virtual void Move()
    {

    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(TagGlossary.ENEMY))
        {
            if(other.TryGetComponent(out IHealth health))
            {
                health.TakeDamage(doDamage());
            }
        }
        if (!other.CompareTag(TagGlossary.PLAYER))
        {
            gameObject.SetActive(false);
        }
    }
}