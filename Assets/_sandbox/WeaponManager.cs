using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;

    [SerializeField] private List<WeaponBaseSettings> _skills = new();
    [SerializeField] private Transform _parent;

    private void Awake()
    {
        Initialize(_playerStats);
    }

    public void Initialize(PlayerStats playerStats)
    {
        foreach (var weapon in _skills)
        {
            var manager = Instantiate(weapon.WeaponManager, _parent);




            //WeaponManagerBase manager = ManagerSpawner.SpawnManager(skill);
            //if (manager != null)
            //{
            //    managers[skill.skillName] = manager;
            //    skillData[skill.skillName] = skill; // <-- Add this line
            //    StartCooldown(skill.skillName, skill.cooldown);
            //}
        }
    }
}
