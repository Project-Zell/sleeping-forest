using System;
using System.Collections.Generic;
using UnityEngine;

namespace Coollel.Stephen
{
    [CreateAssetMenu(fileName = "WaveTimingsSO", menuName = "WaveTimings")]
    public class WaveTimings : ScriptableObject
    {
        public List<WaveDetails> Waves;
    }
    [Serializable]
    public class WaveDetails
    {
        public string WaveName;
        public int StartTime;
        public List<WaveEnemyAmount> EnemyList;
    }

    [Serializable]
    public class WaveEnemyAmount
    {
        public string name;
        public BaseEnemy Enemy;
        public int MaxAmount;
        public bool IsUnique;
    }
}
