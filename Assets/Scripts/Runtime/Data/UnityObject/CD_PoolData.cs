using System.Collections.Generic;
using Runtime.Data.ValueObject;
using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_PoolData", menuName = "Boomerang Warrior/CD_PoolData", order = 0)]
    public class CD_PoolData : ScriptableObject
    {
        public List<PoolData> ObjectData;
    }
}