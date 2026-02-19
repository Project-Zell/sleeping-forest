using Coollel.Stephen;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyWave
{
    public int StartsAt { get; private set; }
    public List<EnemyDataContainer> EnemySpawnDatas { get; private set; } = new();

    public EnemyWave(StageProgressSO.EnemyWaveContainter container)
    {
        StartsAt = container.StartsAt;
        EnemySpawnDatas = new();

        foreach (var enemyWave in container.WaveSettings)
        {
            EnemySpawnDatas.Add(new EnemyDataContainer(enemyWave));
        }
    }

    public class EnemyDataContainer
    {
        public EnemyDataContainer(StageProgressSO.EnemyWaveContainter.EnemyDataContainer waveData)
        {
            EnemyPrefab = waveData.EnemyPrefab;
            MaxAmount = waveData.MaxAmount;
            CurrentAmount = 0;

            _isUnique = waveData.IsUnique;
        }

        public BaseEnemy EnemyPrefab { get; private set; }
        public int MaxAmount { get; private set; }
        public int CurrentAmount { get; private set; }
        public bool IsEnemyCanBeSpawned => CurrentAmount < MaxAmount;
        public void RegisterNewEnemy() => CurrentAmount++;
        public void UnregisterEnemy()
        {
            CurrentAmount--;
            if(_isUnique) MaxAmount--;
        }

        private bool _isUnique = false;
    } 

    public bool CanSpawnMoreEnemys => EnemySpawnDatas.Where(enemy => enemy.IsEnemyCanBeSpawned).Any(); 

    public int GetActiveEnemyCount()
    {
        var enemyCount = 0;
        foreach (var data in EnemySpawnDatas)
            enemyCount += data.CurrentAmount;
        return enemyCount;
    }

    public EnemyDataContainer GetRandomAvailableSpawnDataContainer()
    {
        var readyEnemys = new List<EnemyDataContainer>(EnemySpawnDatas.Where(enemy => enemy.IsEnemyCanBeSpawned).ToList());
        return readyEnemys[Random.Range(0, readyEnemys.Count)];
    }
}
