using System;

namespace Runtime.Data.ValueObject
{
    [Serializable]
    public struct SpawnData
    {
        public EnemySpawnData EnemySpawnData;
        public CoinSpawnData CoinSpawnData;
        public PlayerSpawnData PlayerSpawnData;
        
    }
}