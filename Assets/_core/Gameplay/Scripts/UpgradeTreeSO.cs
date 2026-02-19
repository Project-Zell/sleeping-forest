using UnityEngine;

[System.Serializable]
public class BasicStatUpgradeTree
{
    public enum BonusType
    {
        Flat,
        Persentage,
    }
    [field: SerializeField] public string NameKey { get; private set; }
    [field: SerializeField] public string DescriptionKey { get; private set; }
    [field: SerializeField] public int CurrentTier { get; private set; } = 0;
    [field: SerializeField] public float CurrentBonus { get; private set; } = 0;

    private readonly UnitStat _stat;

    private readonly BonusType _bonusType;
    private readonly int _basicBonus;
    private readonly int _maximumTiers;

    public BasicStatUpgradeTree(BasicStatUpgradeTreeSO constructor, UnitStat stat)
    {
        _stat = stat;

        NameKey = constructor.NameKey;
        DescriptionKey = constructor.DescriptionKey;

        _bonusType = constructor.BonusType;
        _basicBonus = constructor.BasicBonus;
        _maximumTiers = constructor.MaximumTiers;
    }

    public bool IsAvailableForUpgrade => CurrentTier <= _maximumTiers;

    public void RiseTier()
    {
        CurrentTier++;
        CurrentBonus = _bonusType switch
        {
            BonusType.Persentage => _stat.BaseValue * (1 + _basicBonus / 100f * CurrentTier),
            _ => _stat.BaseValue + CurrentTier * _basicBonus,
        };

        _stat.ChangeCurrentValue(CurrentBonus);
    }
}


