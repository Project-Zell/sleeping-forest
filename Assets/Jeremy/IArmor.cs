using UnityEngine;

public interface IArmor
{
    public float ArmorValue { get; set; }
    public void CalculateArmor(float armorValue);
}
