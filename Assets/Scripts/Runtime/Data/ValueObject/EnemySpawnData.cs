using System;
using UnityEngine;

namespace Runtime.Data.ValueObject
{
    [Serializable]
    public struct EnemySpawnData
    {
        public int SpawnLimit;
        public int SpawnRange;
        public GameObject EnemySpawnZone;
    }
}