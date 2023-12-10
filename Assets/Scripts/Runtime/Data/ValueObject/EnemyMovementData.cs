using System;
using System.Security.Cryptography;
using UnityEngine;

namespace Runtime.Data.ValueObject
{
    [Serializable]
    public class EnemyMovementData
    {
        [Range(1f, 5f)]
        public float speed;
    }
}