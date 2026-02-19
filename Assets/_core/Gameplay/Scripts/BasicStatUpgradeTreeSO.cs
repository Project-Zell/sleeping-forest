using UnityEngine;

[CreateAssetMenu(fileName = "New Stat Upgrade Tree", menuName = "Gameplay/Stat Upgrade Tree")]
public class BasicStatUpgradeTreeSO : ScriptableObject
{
    [field: SerializeField] public string NameKey { get; private set; }
    [field: SerializeField] public string DescriptionKey { get; private set; }
    [field: SerializeField] public StatType Stat { get; private set; }
    [field: SerializeField] public BasicStatUpgradeTree.BonusType BonusType { get; private set; }
    [field: SerializeField] public int BasicBonus { get; private set; }
    [field: SerializeField] public int MaximumTiers { get; private set; }
}
