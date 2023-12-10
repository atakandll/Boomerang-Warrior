using System;
using Runtime.Enums.ObjectPooling;
using UnityEngine;

namespace Runtime.Data.ValueObject
{
    [Serializable]
    public class ObjectData
    {
        public PoolObjectType poolObjectType;
        public PoolType poolType;
        public GameObject PoolObject;

        //public string PoolName;
        public int PoolCount;
    }
}