using Runtime.Data.ValueObject;
using UnityEngine;

namespace Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_SpawnData", menuName = "Data/CD_SpawnData", order = 0)]
    public class CD_SpawnData : ScriptableObject
    {
        public SpawnData SpawnData;
    }
}