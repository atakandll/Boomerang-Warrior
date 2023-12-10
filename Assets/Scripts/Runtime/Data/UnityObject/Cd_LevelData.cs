using System.Collections.Generic;
using Runtime.Data.ValueObject;
using UnityEngine;

namespace Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "Cd_LevelData", menuName = "Data/LevelData")]
    public class Cd_LevelData : ScriptableObject
    {
        public List<LevelData> LevelData;
    }
}