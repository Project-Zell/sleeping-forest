using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterUnit : MonoBehaviour, IHealth
{
    public CharacterStats Stats { get; private set; }
    [SerializeField] private PlayerHealthChannel _playerHealthChannel;

    [field: SerializeField] public CharacterUnitStatsSO BaseStats { get; private set; }

    public int CurrentHealth => (int)(Stats.GetStat(StatType.HP) as UnitDynamicStat).ActualValue;
    public int MaxHealth => (int)Stats.GetStat(StatType.HP).CurrentValue;

    public UnityEvent OnDeath => _onDeath;

    [SerializeField] private UnityEvent _onDeath;

    [SerializeField] private List<BasicStatUpgradeTreeSO> _upgradesTrees = new();

    public void Awake()
    {
        Stats = new CharacterStats(BaseStats);
        _playerHealthChannel.RaiseEvent(this);

        GetComponentInChildren<Weapon>().Initialize(Stats);
    }

    private void OnEnable() => Stats.GetStat(StatType.HP).OnStatChanged += () => _playerHealthChannel.RaiseEvent(this);
    private void OnDisable() => Stats.GetStat(StatType.HP).OnStatChanged += () => _playerHealthChannel.RaiseEvent(this);

    public List<BasicStatUpgradeTreeSO> GetUpgradeTrees()
    {
        return new(_upgradesTrees);
    }

    public void TakeDamage(float damage)
    {
        _playerHealthChannel.RaiseEvent(this);
        var stat = (Stats.GetStat(StatType.HP) as UnitDynamicStat);
        stat.ChangeActualValue(CurrentHealth - damage);
        if(stat.ActualValue <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        OnDeath?.Invoke();
    }

    private void Update()
    {
        Debug.Log(Stats.GetStat(StatType.AttackPower).CurrentValue);
    }
}