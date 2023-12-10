using System.Collections.Generic;
using Runtime.Data.ValueObject;
using UnityEngine;
using UnityEngine.Serialization;

namespace Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "Cd_Pool", menuName = "Data/ObjectPool")]
    public class Cd_ObjectData : ScriptableObject
    {
        public List<ObjectData> ObjectData;
    }
}