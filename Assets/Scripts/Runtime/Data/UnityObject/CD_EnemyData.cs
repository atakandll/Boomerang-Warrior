using Runtime.Data.ValueObject;
using UnityEngine;

namespace Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_EnemyData", menuName = "Boomerang Warrior/CD_EnemyData", order = 0)]
    public class CD_EnemyData : ScriptableObject
    {
        public EnemyData EnemyData;
    }
}