using UnityEngine;

public class Torch : StrikeBase
{
    // Static activation method, similar to Fireball
    public SkillSO torchSO;

    private void Start()
    {
        Initialize(torchSO);
        transform.position = torchSO.spawnOffset;
    }

    private void OnEnable()
    {
        //Initialize(torchSO, origin);      //if uncommented calls debug log warning in strikebase:46
    }

    public void PerformAttack()
    {
        Vector3 origin = transform.position;
        Vector3 forward = transform.forward;

        Collider[] hits = Physics.OverlapSphere(origin, AttackRadius);

        //Debug.Log("Attack");

        foreach (Collider hit in hits)
        {
            //Debug.Log("Collider");
            Vector3 directionToTarget = (hit.transform.position - origin).normalized;
            float angleToTarget = Vector3.Angle(forward, directionToTarget);

            //if (angleToTarget <= AttackAngle * 0.5f)
            {
                if (hit.CompareTag("Enemy"))
                {
                    if (hit.TryGetComponent(out IHealth health))
                    {
                        health.TakeDamage(doDamage());
                    }
                    //Debug.Log("Torch hit enemy: " + hit.name);
                    // Example: hit.GetComponent<Enemy>().TakeDamage(damage);
                }
            }
        }
    }

    // Visualize the attack area in the Scene view
    private void OnDrawGizmosSelected()
    {
        Vector3 origin = transform.position;
        Vector3 forward = transform.forward;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(origin, AttackRadius);

        Vector3 leftLimit = Quaternion.Euler(0, -AttackAngle * 0.5f, 0) * forward;
        Vector3 rightLimit = Quaternion.Euler(0, AttackAngle * 0.5f, 0) * forward;

        Gizmos.DrawLine(origin, origin + leftLimit * AttackRadius);
        Gizmos.DrawLine(origin, origin + rightLimit * AttackRadius);
    }
}
