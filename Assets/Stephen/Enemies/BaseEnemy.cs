using System;
using UnityEngine;
using UnityEngine.Events;

namespace Coollel.Stephen
{
    [System.Serializable]
    public class BaseEnemy : MonoBehaviour, IHealth
    {
        [field:SerializeField] public string Name { get; private set; }
        [SerializeField] protected EnemyBehaviour _enemyBehaviour;
        [SerializeField] protected DamagePopupChannel _channel;

        public int CurrentHealth => health;

        public int MaxHealth => throw new System.NotImplementedException();

        public UnityEvent OnDeath => onDeath;
        [SerializeField] private UnityEvent onDeath;

        [SerializeField] private int health = 10;
        [SerializeField] private int damage = 7;
        public int Damage => damage;
        
        [SerializeField] private bool scaleStats = false;

        private Vector3 offset = new Vector3(0, 1, 0);

        private EnemyManager enemyManager;

        public void Init(EnemyManager enemyManager, Transform playetTransform, float gameTime)
        {
            this.enemyManager = enemyManager;
            _enemyBehaviour.Initiazlie(playetTransform);
            if (scaleStats)
            {
                UpgradeStats(gameTime);
            }
        }

        public void Initialize(Transform playerTransform)
        {
            _enemyBehaviour.Initiazlie(playerTransform);
        }

        public void SetLocation(Vector3 location)
        {
            _enemyBehaviour.MoveToValidNavMesh(location);
        }

        protected virtual void Die()
        {
            if (enemyManager)
            {
                enemyManager.RemoveOneEnemy(Name);
            }
            OnDeath?.Invoke();
            OnDeath.RemoveAllListeners();
            Destroy(gameObject);
        }

        public void TakeDamage(float damage)
        {
            health -= (int)damage;
            _channel.RaiseEvent(new DamagePopupContainer(transform.position + offset, (int)damage));
            if(health <= 0)
            {
                Die();
            }
        }

        public void UpgradeStats(float spawnTime)
        {
            float startScalingTime = 180;
            int multiplier = (int)Mathf.Clamp((spawnTime - startScalingTime) / 20, 1, Mathf.Infinity);
            print($"Scaled by {multiplier}.");
            health = health * multiplier;
        }

        public void SubscribeToDeathEvent(UnityAction action) => onDeath.AddListener(action);
        public void UnsubscribeFromDeathEvent(UnityAction action) => onDeath.RemoveListener(action);
    }
}
