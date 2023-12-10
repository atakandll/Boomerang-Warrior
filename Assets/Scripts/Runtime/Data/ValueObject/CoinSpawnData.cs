using System;
using UnityEngine;

namespace Runtime.Data.ValueObject
{
    [Serializable]
    public class CollectableSpawnData
    {
        public int spawnLimit;

        public GameObject collectableSpawnZone;
    }
}