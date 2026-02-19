using Coollel.Stephen;
using UnityEngine;

public class ContactDamage : MonoBehaviour
{
    [SerializeField]
    private string CollidableTag = TagGlossary.PLAYER;
    [SerializeField]
    private BaseEnemy enemy;
    //private float Damage = 7;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(CollidableTag))
        {
            if(other.TryGetComponent(out IHealth health))
            {
                health.TakeDamage(enemy.Damage);
            }
        }
    }
}
