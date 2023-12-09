using System;
using Runtime.Enums.ObjectPooling;
using UnityEngine;

namespace Runtime.Data.ValueObject
{
    [Serializable]
    public struct PoolData
    {
        public PoolObjectType PoolObjectType;
        public PoolType PoolType;
        public GameObject PoolObject;
        public int PoolCount;
    }
}