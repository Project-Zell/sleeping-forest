using Coollel.Luca;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public List<SkillSO> skills;

    private Dictionary<string, float> cooldowns = new Dictionary<string, float>();

    private Dictionary<string, WeaponManagerBase> managers = new();
    private Dictionary<string, SkillSO> skillData = new();


    private void Start()
    {
    }

    void Awake()
    {
        foreach (SkillSO skill in skills)
        {
            WeaponManagerBase manager = ManagerSpawner.SpawnManager(skill);
            if (manager != null)
            {
                managers[skill.skillName] = manager;
                skillData[skill.skillName] = skill; // <-- Add this line
                StartCooldown(skill.skillName, skill.cooldown);
            }
            else
            {
                Debug.LogWarning($"Skill prefab for {skill.skillName} does not have a WeaponManagerBase component!");
            }
        }
    }

    public void AddWeapon(WeaponBaseStats weaponBase)
    {


    }

    void Update()
    {
        //foreach (var kvp in managers)
        //{
        //    string skillName = kvp.Key;
        //    WeaponManagerBase manager = kvp.Value;

        //    if (IsReady(skillName))
        //    {
        //        switch (skillName)
        //        {
        //            case "Fireball":
        //                ((FireBallPool)manager).Attack();
        //                //Debug.Log("Fireball");
        //                StartCooldown(skillName, fireBall.cooldown);
        //                break;
        //            case "Torch":
        //                ((TorchManager)manager).Attack();
        //                //Debug.Log("Torch");
        //                StartCooldown(skillName, torch.cooldown);
        //                break;
        //            case "Lantern":
        //                ((LanternManager)manager).Attack();
        //                //manager.gameObject.SetActive(true);
        //                Debug.Log("Lantern");
        //                StartCooldown(skillName, lantern.cooldown);
        //                break;
        //        }
        //    }
        //}


        foreach (var kvp in managers)
        {
            string skillName = kvp.Key;
            WeaponManagerBase manager = kvp.Value;

            if (IsReady(skillName))
            {
                manager.Attack(); // Or manager.Activate(), etc.
                StartCooldown(skillName, skillData[skillName].cooldown);
            }
        }
    }

    // Cooldown Management
    public void StartCooldown(string skillName, float cooldownDuration)
    {
        cooldowns[skillName] = Time.time + cooldownDuration;
    }

    public bool IsReady(string skillName)
    {
        if (!cooldowns.ContainsKey(skillName)) return false;
        return Time.time >= cooldowns[skillName];
    }

    public float GetTimeRemaining(string skillName)
    {
        if (!cooldowns.ContainsKey(skillName)) return 0f;
        return Mathf.Max(0f, cooldowns[skillName] - Time.time);
    }
}