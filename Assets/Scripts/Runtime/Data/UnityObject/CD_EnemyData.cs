using Runtime.Data.ValueObject;
using UnityEngine;

namespace Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_Enemy", menuName = "Boomerang Warrior/CD_Enemy", order = 0)]
    public class CD_EnemyData : ScriptableObject
    {
        public EnemyData EnemyData;
    }
}