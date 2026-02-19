using UnityEngine;

[System.Serializable]
public class UnitDynamicStat : UnitStat
{
    [field: SerializeField] public float ActualValue { get; protected set; } = 0f;

    public UnitDynamicStat(float baseValue, StatType type) : base(baseValue, type)
    {
        ActualValue = baseValue;
    }

    public void ChangeActualValue(float value)
    {
        ActualValue = value;
    }

    public override string GetCurrentValueString()
    {
        return $"{ActualValue}/{CurrentValue}";
    }
}
