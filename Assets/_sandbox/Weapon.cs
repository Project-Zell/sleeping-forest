using UnityEngine;

public class Weapon : MonoBehaviour
{
    [field: SerializeField] public bool IsActive { get; protected set; } = false;

    protected CharacterStats _playerStats;

    public void Initialize(CharacterStats playerStats)
    {
        _playerStats = playerStats;
    }
}
