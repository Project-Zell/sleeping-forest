using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class SkillPool : ScriptableObject
{
    [SerializeField] private List<SkillSO> _availableWeapons;

    public List<SkillSO> GetAllWeapons()
    {
        return _availableWeapons;
    }

    public SkillSO GetWeapon(string weaponName)
    {
        var weapon = _availableWeapons.FirstOrDefault(weapon => weapon.skillName == weaponName);

        if (weapon == null)
        {
            Debug.LogError($"[WeaponPool] Weapon '{weaponName}' not found.");
            throw new Exception();
        }

        return weapon;

    }
}