using System.Collections.Generic;
using System.Linq;

public class CharacterStats 
{
    public List<UnitStat> Stats { get; private set; } = new();

    public UnitStat GetStat(StatType statType)
    {
        return Stats.First(stat => stat.Type == statType);
    }

    public CharacterStats(CharacterUnitStatsSO constructor)
    {
        foreach(var stat in constructor.Stats)
        {
            if (stat.StatStarterType is CharacterUnitStatsSO.StatStarterType.Dynamic)
            {
                Stats.Add(new UnitDynamicStat(stat.Value, stat.Type));
            }
            else
            {
                Stats.Add(new UnitStat(stat.Value, stat.Type));
            }
        }
    }
}
