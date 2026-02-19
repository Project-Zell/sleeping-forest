using UnityEngine;

namespace Coollel.Stephen
{
    public class TestEnemy : BaseEnemy
    {
        void Start()
        {

        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.J))
            {
                TakeDamage(1);
                Die();
            }
        }
    }
}