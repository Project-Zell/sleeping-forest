using Coollel.Stephen;
using System;
using System.Threading.Tasks;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] private GameTime _gameTime;
    [SerializeField] private BoundValues _bounds;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private GameObject _enemyParent;

    [Header("Settings")]
    [Tooltip("Delay in milliseconds. 1 second is 1000 milliseconds.")]
    [SerializeField] private int _spawnDelay = 1;
    
    [SerializeField] private StageProgression _stageProgression;
    [SerializeField] private EnemyWave _currentWave;
    
    private event Action<string> OnEnemySpawn;
    private event Action<string> OnEnemyDeath;

    private void OnEnable()=> _gameTime.SubscribeToIntervalPassed((time) => CheckNextWave(time));
    private void OnDisable()=> _gameTime.UnsubscribeFromIntervalPassed((time) => CheckNextWave(time));

    public void SubscribeToEnemySpawn(Action<string> callback) => OnEnemySpawn += callback;
    public void UnsubscribeFromEnemySpawn(Action<string> callback) => OnEnemySpawn -= callback;
    public void SubscribeToEnemyDeath(Action<string> callback) => OnEnemyDeath += callback;
    public void UnsubscribeFromEnemyDeath(Action<string> callback) => OnEnemyDeath -= callback;

    public void Initialize(StageProgressSO stage)
    {
        _stageProgression = new StageProgression();
        _stageProgression.Initialize(stage);
    }

    public void EnableSpawning() => CheckCurrentWave();

    private void CheckNextWave(float time)
    {
        if (_stageProgression.IsNextWaveReadyToStart(time))
        {
            _currentWave = _stageProgression.GetNextEnemyWave();
            CheckCurrentWave();
        }
    }

    private void CheckCurrentWave()
    {
        if(_currentWave.CanSpawnMoreEnemys) 
        {
            SpawnEnemy(_currentWave.GetRandomAvailableSpawnDataContainer());
            CheckCurrentWave();
        }
    }

    private async void SpawnEnemy(EnemyWave.EnemyDataContainer dataContainer)
    {
        if (dataContainer.IsEnemyCanBeSpawned is false)
            return;

        dataContainer.RegisterNewEnemy();
        
        await Task.Delay(_spawnDelay);

        BaseEnemy enemy = Instantiate(dataContainer.EnemyPrefab, _enemyParent.transform);
        enemy.Initialize(_playerTransform);

        var spawnLocation = GetRandomPointOnBounds(_bounds);
        enemy.SetLocation(spawnLocation + _playerTransform.position);

        enemy.SubscribeToDeathEvent(() => dataContainer.UnregisterEnemy());
        enemy.SubscribeToDeathEvent(() => CheckCurrentWave());
        enemy.SubscribeToDeathEvent(() => EnemyDeathCallback(enemy.Name));

        OnEnemySpawn?.Invoke(enemy.Name);
    }

    private void EnemyDeathCallback(string enemyName)
    {
        OnEnemyDeath?.Invoke(enemyName);
    }

    private Vector3 GetRandomPointOnBounds(BoundValues spawnBounds)
    {
        int random = UnityEngine.Random.Range(0, 4);

        float left = spawnBounds.TopLeftBound.x;
        float top = spawnBounds.TopLeftBound.y;
        float right = spawnBounds.BottomRightBound.x;
        float bot = spawnBounds.BottomRightBound.y;

        float x = 0, y = 0;

        switch (random)
        {
            case 0:
                y = top;
                x = UnityEngine.Random.Range(left, right);
                break;
            case 1:
                x = right;
                y = UnityEngine.Random.Range(bot, top);
                break;
            case 2:
                y = bot;
                x = UnityEngine.Random.Range(left, right);
                break;
            case 3:
                x = left;
                y = UnityEngine.Random.Range(bot, top);
                break;
        }
        return new Vector3(x, spawnBounds.OffSet, y);
    }

    [Serializable]
    public class BoundValues
    {
        [field: SerializeField] public Vector2 TopLeftBound { get; private set; }
        [field: SerializeField] public Vector2 BottomRightBound { get; private set; }
        [field: SerializeField] public float OffSet { get; private set; }
    }
}
