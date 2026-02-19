using Coollel.Stephen;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stage Progression", menuName = "Gameplay/Stage Progression")]
public class StageProgressSO : ScriptableObject
{
    [SerializeField] private List<EnemyWaveContainter> EnemyWaves = new();

    [System.Serializable]
    public class EnemyWaveContainter
    {
        [field: SerializeField] public int StartsAt { get; private set; }
        [field: SerializeField] public List<EnemyDataContainer> WaveSettings { get; private set; } = new();

        [System.Serializable]
        public class EnemyDataContainer
        {
            [field: SerializeField] public BaseEnemy EnemyPrefab { get; private set; }
            [field: SerializeField] public int MaxAmount { get; private set; }
            [field: SerializeField] public bool IsUnique { get; private set; }
        }
    }

    public List<EnemyWave> GetEnemyWaves()
    {
        var enemyWavesList = new List<EnemyWave>();
        foreach(var enemyWaveContainer in EnemyWaves)
        {
            enemyWavesList.Add(new EnemyWave(enemyWaveContainer));
        }
        return enemyWavesList;
    }
}