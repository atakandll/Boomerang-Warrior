using Runtime.Data.ValueObject;
using UnityEngine;

namespace Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "Cd_SpawnData", menuName = "Data/SpawnData ")]
    public class Cd_SpawnData : ScriptableObject
    {
        public SpawnData SpawnData;
    }
}