using System.Collections.Generic;

public class WeaponStat 
{
    public enum StatType { Flat, Persentage }
    public StatType Type { get; private set; }

    public int BaseStat { get; private set; }
    public int CurrentStat { get; private set; }
    
    public WeaponStat(int baseStat, StatType type)
    {
        BaseStat = baseStat;
        CurrentStat = BaseStat;
        Type = type;
    }
}