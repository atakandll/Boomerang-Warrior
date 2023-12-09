using System;
using System.Security.Cryptography;
using UnityEngine;

namespace Runtime.Data.ValueObject
{
    [Serializable]
    public struct EnemyMovementData
    {
        [Range(1f, 5f)] public float Speed;
    }
}