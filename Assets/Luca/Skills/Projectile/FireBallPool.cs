using UnityEngine;
using System.Collections.Generic;

public class FireBallPool : WeaponManagerBase
{
    public static FireBallPool Instance;
    private GameObject fireballPrefab;
    public int poolSize = 6;
    private List<Fireball> pool;//list iof fireba;;s
    public SkillSO fireballSO;

    private Transform parentTransform;

    private void Start()
    {
        fireballPrefab = fireballSO.SkillPrefab;
    }

    private void Awake()
    {
        Instance = this;
        pool = new List<Fireball>();
        if (fireballPrefab)
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject obj = Instantiate(fireballPrefab);
                obj.SetActive(false);
                pool.Add(obj.GetComponent<Fireball>());
            }
        }
        else
        {
            Debug.Log("fireball prefab not assigned, still everything works so dont worry");
        }
        parentTransform = GameObject.FindWithTag("Player").transform;
    }

    public void GetFireball()
    {
        SkillSO values = fireballSO;
        Vector3 spawnPos = GetFiringPosition();
        Quaternion rotation = GetFiringRotation();

        foreach (var obj in pool)
        {
            if (!obj.gameObject.activeInHierarchy)
            {
                obj.ActivateFireball(values, spawnPos, rotation);
                return;
            }
        }
        GameObject moreFireball = Instantiate(fireballPrefab);
        moreFireball.SetActive(false);
        Fireball newFireball = moreFireball.GetComponent<Fireball>();
        pool.Add(newFireball);
        newFireball.ActivateFireball(values, spawnPos, rotation);
    }

    public override void Attack()
    {
        base.Attack();
        GetFireball();
    }

    public Vector3 GetFiringPosition()
    {
        Vector3 forwardOffset = parentTransform.forward * fireballSO.spawnOffset.x;
        Vector3 upOffset = parentTransform.up * fireballSO.spawnOffset.y;
        Vector3 rightOffset = parentTransform.right * fireballSO.spawnOffset.z; // in case you want to use z for right

        return parentTransform.position + forwardOffset + upOffset + rightOffset;
    }

    public Quaternion GetFiringRotation() => parentTransform.rotation;
}
