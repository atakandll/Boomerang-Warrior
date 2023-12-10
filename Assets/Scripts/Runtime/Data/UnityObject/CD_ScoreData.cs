using Runtime.Data.ValueObject;
using UnityEngine;

namespace Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_ScoreData", menuName = "Boomerang Warrior/CD_ScoreData", order = 0)]
    public class CD_ScoreData : ScriptableObject
    {
        public ScoreData ScoreData;
        private const string Key = "scoreData";
        private const string uniqueID = "1";
        
        public string GetKey()
        {
            return Key;
        }
    }
}