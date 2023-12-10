using Runtime.Data.ValueObject;
using UnityEngine;

namespace Runtime.Data.UnityObject
{[CreateAssetMenu(fileName = "Cd_EnemyData", menuName = "Data/EnemyData")]
    public class Cd_EnemyData : ScriptableObject
    {
        public EnemyData EnemyData;
    }
}