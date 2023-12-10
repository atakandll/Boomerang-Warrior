using System;
using UnityEngine;

namespace Runtime.Data.ValueObject
{
    [Serializable]
    public struct CoinSpawnData
    {
        public int SpawnLimit;
        public GameObject CoinSpawnZone;

    }
}