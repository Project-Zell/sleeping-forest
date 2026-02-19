using UnityEngine;

namespace Coollel.Stephen
{
    public class EXPCollector : MonoBehaviour
    {
        [SerializeField]
        private PlayerLevelManager playerLevelManager;
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out ExpOrb exp))
            {
                playerLevelManager.GainEXP(exp.expAmount);
                Destroy(exp.gameObject);
            }
        }
    }
}