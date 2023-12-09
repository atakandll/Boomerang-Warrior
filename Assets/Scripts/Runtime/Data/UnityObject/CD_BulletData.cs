using Runtime.Data.ValueObject;
using UnityEngine;

namespace Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_BulletData", menuName = "Boomerang Warrior/CD_BulletData", order = 0)]
    public class CD_BulletData : ScriptableObject
    {
        public BulletData BulletData;
    }
}