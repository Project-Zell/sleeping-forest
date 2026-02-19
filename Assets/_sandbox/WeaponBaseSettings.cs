using UnityEngine;

[CreateAssetMenu(fileName = "New Settings", menuName = "Weapon")]
public class WeaponBaseSettings : ScriptableObject
{
    [field: SerializeField] public GameObject WeaponManager { get; private set; }
    [field: SerializeField] public WeaponBaseStats WeaponStats { get; private set; }
}