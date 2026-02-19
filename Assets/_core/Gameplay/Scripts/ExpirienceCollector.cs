using UnityEngine;

public class ExpirienceCollector : MonoBehaviour
{
    [SerializeField] private PlayerLevelProgression _playerLevelProgression;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ExpOrb exp))
        {
            _playerLevelProgression.GainExperience(exp.expAmount);
            Destroy(exp.gameObject);
        }
    }
}
