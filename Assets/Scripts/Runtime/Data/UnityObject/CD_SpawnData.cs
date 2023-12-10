using Runtime.Data.ValueObject;
using UnityEngine;

namespace Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_SpawnData", menuName = "Boomerang Warrior/CD_SpawnData")]
    public class CD_SpawnData : ScriptableObject
    {
        public SpawnData SpawnData;
    }
}