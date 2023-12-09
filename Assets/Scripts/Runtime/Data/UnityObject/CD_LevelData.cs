using System.Collections.Generic;
using Runtime.Data.ValueObject;
using UnityEngine;

namespace Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_LevelData", menuName = "Boomerang Warrior/CD_LevelData", order = 0)]
    public class CD_LevelData : ScriptableObject
    {
        public List<LevelData> LevelData;
    }
}