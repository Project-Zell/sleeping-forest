using System;
using UnityEngine;

[System.Serializable]
public class UnitStat
{
    public StatType Type;

    public readonly float BaseValue;
    [field: SerializeField] public float CurrentValue { get; protected set; } = 0f;

    public event Action OnStatChanged;

    public UnitStat(float baseValue, StatType type)
    {
        BaseValue = baseValue;
        CurrentValue = BaseValue;
        Type = type;
    }

    public virtual void ChangeCurrentValue(float value)
    {
        CurrentValue = value;
        OnStatChanged?.Invoke();
    }

    public virtual string GetCurrentValueString()
    {
        return $"{CurrentValue}";
    }
}
