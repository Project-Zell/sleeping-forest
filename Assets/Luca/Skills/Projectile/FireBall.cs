using UnityEngine;

public class Fireball : ProjectileBase
{
    public void ActivateFireball(SkillSO values, Vector3 spawnPos, Quaternion rotation)
    {

        timeNow = 0;
        /*
        Vector3 spawnPos = firePoint.position;
        Vector3 shootDirection = firePoint.forward;
        Quaternion rotation = Quaternion.LookRotation(shootDirection);*/

        transform.position = spawnPos;
        transform.rotation = rotation;
        gameObject.SetActive(true);

        Vector3 shootDirection = rotation * Vector3.forward;

        Initialize(values);
        SetVelocity(shootDirection);
    }

    private void resetTimeNow()
    {
        timeNow = 0;
    }

    public override void Move()
    {
        base.Move();
   
        timeNow += Time.deltaTime;
        if (timeNow >= Lifetime)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
            return;
        }
        transform.position += velocity * Time.deltaTime;
    }
}