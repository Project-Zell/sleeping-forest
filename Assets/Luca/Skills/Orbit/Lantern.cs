using UnityEngine;

public class Lantern : OrbitBase
{
    //public Transform target; // Will be set to parent

    public SkillSO values;

    private GameObject parent;

    private GameObject player;


    public void ActivateOrbit(SkillSO values, Transform firePoint)
    {
        timeNow = 0;

        Initialize(values);
    }

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        parent = transform.parent.gameObject;
    }

    private void OnEnable()
    {
        ActivateOrbit(values, parent.transform);
    }

    public override void Move()
    {
        base.Move();

        timeNow += Time.deltaTime;
        if (timeNow >= Lifetime)
        {
            parent.SetActive(false);
            //Destroy(gameObject);
            return;
        }
        Orbit(player.transform, Speed, Radius);
        transform.position = transform.position + SpawnOffset;
    }
}