using UnityEngine;

public class LanternManager : WeaponManagerBase
{
    private GameObject lanternPrefab;
    public int numberOfLanterns = 2;
    public SkillSO lanternSO;

    private void Start()
    {
        lanternPrefab = lanternSO.SkillPrefab;
        SpawnLanterns();
    }

    public override void Attack()
    {
        base.Attack();
       //Debug.Log("attacking");
        foreach (Transform holder in transform)
        {
            // Ensure the holder is active
            holder.gameObject.SetActive(true);

            Lantern lantern = holder.GetComponentInChildren<Lantern>(true);
            if (lantern != null && lantern.gameObject != null)
            {
                lantern.gameObject.SetActive(true);
                lantern.ActivateOrbit(lanternSO, transform);
            }
            else
            {
                //Debug.LogWarning("Lantern not found as child of holder: " + holder.name);
            }
        }
    }




    public void UpgradeNumberOfLanterns()
    {
        numberOfLanterns++;
        SpawnLanterns();
    }

    public void SpawnLanterns()
    {
        foreach (Transform child in transform)
        {
           //Debug.Log("Destroying: " + child.name);
            Destroy(child.gameObject);
        }

        if (lanternPrefab == null || lanternSO == null) return;

        for (int i = 0; i < numberOfLanterns; i++)
        {
            float angleDegrees = i * 360f / numberOfLanterns;
            SpawnLantern(angleDegrees);
        }
    }


    private void SpawnLantern(float startAngleDegrees)
    {
        GameObject middle = new GameObject("LanternHolder");
        middle.transform.SetParent(transform);
        middle.transform.localPosition = Vector3.zero;

        GameObject lantern = Instantiate(lanternPrefab, middle.transform);
        lantern.transform.localScale = lanternSO.scale;
        lantern.SetActive(false);

        Lantern lanternScript = lantern.GetComponent<Lantern>();
        if (lanternScript != null)
        {
            lanternScript.startAngle = startAngleDegrees;
            lanternScript.Radius = lanternSO.radius;
            lanternScript.Speed = lanternSO.speed;
            lanternScript.Initialize(lanternSO);
        }
        else
        {
           //Debug.LogError("Lantern prefab does not have Lantern script attached!");
        }
    }

}
