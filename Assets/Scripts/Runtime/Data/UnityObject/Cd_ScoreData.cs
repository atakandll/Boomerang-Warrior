using Runtime.Data.ValueObject;
using UnityEngine;

namespace Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "Cd_ScoreData", menuName = "Data/ScoreData")]
    public class Cd_ScoreData : ScriptableObject
    {
        public ScoreData ScoreData;

        private const string Key = "scoreData";

        private const string uniqID = "1";

        public string GetKey()
        {
            return Key;
        }
    }
}