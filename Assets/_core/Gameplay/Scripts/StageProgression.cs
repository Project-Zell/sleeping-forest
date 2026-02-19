using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class StageProgression
{
    [SerializeField] private Queue<EnemyWave> enemyWavesQueue = new();

    public void Initialize(StageProgressSO stage)
    {
        var enemyWaves = stage.GetEnemyWaves();
        enemyWavesQueue = new Queue<EnemyWave>(enemyWaves.OrderBy(wave => wave.StartsAt));
    }

    public bool IsNextWaveReadyToStart(float time)
    {
        if(enemyWavesQueue.Count is 0)
            return false;

        return time >= enemyWavesQueue.Peek().StartsAt;
    }

    public EnemyWave GetNextEnemyWave()
    {
        return enemyWavesQueue.Dequeue();
    }
}
