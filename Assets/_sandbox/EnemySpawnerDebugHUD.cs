using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawnerDebugHUD : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private TextMeshProUGUI _textBase;
    private Dictionary<string, int> _enemyTracker = new();

    private void OnEnable()
    {
        _spawner.SubscribeToEnemySpawn(AddEnemyToTracker);
        _spawner.SubscribeToEnemyDeath(RemoveEnemyFromTracker);
    }
    private void OnDisable()
    {
        _spawner.UnsubscribeFromEnemySpawn(AddEnemyToTracker);
        _spawner.UnsubscribeFromEnemyDeath(RemoveEnemyFromTracker);
    }

    private void AddEnemyToTracker(string enemyName)
    {
        if (_enemyTracker.TryAdd(enemyName, 1) is false)
        {
            _enemyTracker[enemyName]++;
        }
        UpdateHUD();
    }

    private void RemoveEnemyFromTracker(string enemyName)
    {
        _enemyTracker[enemyName]--;
        UpdateHUD();
    } 

    private void UpdateHUD() 
    {
        string debugInfo = string.Empty;
        foreach(var pair in _enemyTracker)
        {
            debugInfo += $"{pair.Key}: {pair.Value}\n";
        }
        _textBase.text = debugInfo;
    }
}
