using System;
using UnityEngine;

namespace Runtime.Data.ValueObject
{
    [Serializable]
    public class EnemySpawnData
    {
        public int spawnLimit;

        public int spawnRange;

        public GameObject enemySpawnZone;
    }
}