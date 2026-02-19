using UnityEngine;

public class ManagerSpawner : MonoBehaviour
{
    public static void spawnLantern(SkillSO lanternSO)
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject prefab = Instantiate(lanternSO.SkillManagerPrefab, player.transform.position, player.transform.rotation, player.transform);
    }

    public static void spawnPool(SkillSO fireballSO)
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject prefab = Instantiate(fireballSO.SkillManagerPrefab, player.transform.position, player.transform.rotation, player.transform);
    }

    public static void spawnTorch(SkillSO torchSO)
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject prefab = Instantiate(torchSO.SkillManagerPrefab, player.transform.position, player.transform.rotation, player.transform);
    }

    //public static void spawnManager(SkillSO skill)
    //{
    //    GameObject player = GameObject.FindWithTag("Player");
    //    GameObject prefab = Instantiate(skill.SkillManagerPrefab, player.transform.position, player.transform.rotation, player.transform);
    //}

    public static WeaponManagerBase SpawnManager(SkillSO skill)
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject prefab = Object.Instantiate(skill.SkillManagerPrefab, player.transform.position, player.transform.rotation, player.transform);
        return prefab.GetComponent<WeaponManagerBase>();
    }


}