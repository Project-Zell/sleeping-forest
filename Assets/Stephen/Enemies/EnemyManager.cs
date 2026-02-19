using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Coollel.Stephen
{
    public class EnemyManager : MonoBehaviour
    {
        [SerializeField]
        public GameObject baseEnemy;
        [SerializeField]
        private BoundValues bounds;
        [SerializeField]
        private Transform playerTransform;
        [SerializeField]
        private WaveTimings waveTiming;
        //[SerializeField]
        //private NavMesh 

        private Dictionary<string, int> currentEnemies = new Dictionary<string, int>();
        private int waveIndex = -1;
        private float currentTime = 0;
        private WaveDetails currentWave = new();
        private GameObject enemyParent;

        //External Test
        [SerializeField] private GameTime _gameTime;

        private void OnEnable()
        {
            //GameFlowManager.OnTimeIntervalPassed += SpawnNextWave;

            //Test
            _gameTime.SubscribeToIntervalPassed((time) => SpawnNextWave(time));
        }
        private void OnDisable()
        {
            //GameFlowManager.OnTimeIntervalPassed -= SpawnNextWave;

            //Test
            _gameTime.UnsubscribeFromIntervalPassed((time) => SpawnNextWave(time));
        }

        private void Start()
        {
            InitNextWave();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                foreach(var thing in currentEnemies)
                {
                    print(thing);
                }
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                SpawnNextWave(1);
            }
        }

        private void SpawnEnemy(BaseEnemy enemyToSpawn, Vector3 location)
        {
            if (!enemyParent)
            {
                enemyParent = new GameObject();
                enemyParent.name = "Enemy Parent";
            }

            BaseEnemy enemy = Instantiate(enemyToSpawn, enemyParent.transform);
            enemy.Init(this, playerTransform, _gameTime.CurrentTime);
            enemy.SetLocation(location + playerTransform.position);

            currentEnemies[enemyToSpawn.Name] += 1;
        }

        private void SpawnNextWave(float l)
        {
            if(HasNextWave() && currentTime >= waveTiming.Waves[waveIndex + 1].StartTime)
            {
                InitNextWave();
            }
            foreach(var enemyDetails in currentWave.EnemyList)
            {
                for (int i = 0; i < enemyDetails.MaxAmount; i++)
                {
                    Vector3 spawnLoc = GetRandomPointOnBounds(bounds);
                    SpawnEnemy(enemyDetails.Enemy, spawnLoc);
                }
            }
        }

        private void InitNextWave()
        {
            waveIndex += 1;
            currentWave = waveTiming.Waves[waveIndex];
            foreach(var enemyDetails in currentWave.EnemyList)
            {
                string enemyName = enemyDetails.Enemy.Name;
                if (!currentEnemies.ContainsKey(enemyName))
                {
                    currentEnemies.Add(enemyName, 0);
                }
            }
        }

        private bool HasNextWave()
        {
            return waveIndex < waveTiming.Waves.Count - 1;
        }

        public void RemoveOneEnemy(string enemyName)
        {
            if (!currentEnemies.ContainsKey(enemyName))
            {
                print("You did something wrong.");
                return;
            }
            currentEnemies[enemyName] -= 1;
        }

        private Vector3 GetRandomPointOnBounds(BoundValues spawnBounds)
        {
            int random = Random.Range(0, 4);

            float left = spawnBounds.TopLeft.x;
            float top = spawnBounds.TopLeft.y;
            float right = spawnBounds.BotRight.x;
            float bot = spawnBounds.BotRight.y;

            float x = 0, y = 0;

            switch (random)
            {
                case 0:
                    y = top;
                    x = Random.Range(left, right);
                    break;
                case 1:
                    x = right;
                    y = Random.Range(bot, top);
                    break;
                case 2:
                    y = bot;
                    x = Random.Range(left, right);
                    break;
                case 3:
                    x = left;
                    y = Random.Range(bot, top);
                    break;
            }
            return new Vector3(x, spawnBounds.offSet, y);
        }

        [Serializable]
        public class BoundValues
        {
            public Vector2 TopLeft;
            public Vector2 BotRight;
            public float offSet;
        }
    }
}
