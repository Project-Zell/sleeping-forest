using UnityEngine;

public class StageInjection : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private StageProgressSO _stage;

    private void Awake()
    {
        _enemySpawner.Initialize(_stage);
    }
}
