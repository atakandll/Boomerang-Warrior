using System;

namespace Runtime.Data.ValueObject
{
    [Serializable]
    public class SpawnData
    {
        public EnemySpawnData enemySpawnData;

        public PlayerSpawnData playerSpawnData;

        public CollectableSpawnData collectableSpawnData;
    }
}