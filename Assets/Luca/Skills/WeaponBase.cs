using UnityEngine;

namespace Coollel.Luca
{
    public abstract class WeaponBase : MonoBehaviour
    {
        public string SkillName;
        public float Cooldown;
        public float Damage;
        public float DamageOverTime;
        public float ArmorReduction;
        public float MovementSpeedReduction;
        public float Speed;
        public float AttackRadius;
        public float AttackAngle;
        public float Lifetime;
        public float Radius;
        public Vector3 SpawnOffset;
        public Vector3 Scale;

        public virtual void Initialize(SkillSO skillBase)
        {
            SkillName = skillBase.skillName;
            Cooldown = skillBase.cooldown;
            Damage = skillBase.damage;
            DamageOverTime = skillBase.damageOverTime;
            ArmorReduction = skillBase.armorReduction;
            MovementSpeedReduction = skillBase.movementSpeedReduction;
            Speed = skillBase.speed;
            AttackRadius = skillBase.attackRadius;
            AttackAngle = skillBase.attackAngle;
            Lifetime = skillBase.lifetime;
            SpawnOffset = skillBase.spawnOffset;
            Scale = skillBase.scale;
            //transform.position = skillValues.spawnOffset;
        }
    
        public virtual void Activate()
        {

        }

        public virtual void Deactivate()
        {

        }
    }
}
