using Runtime.Data.ValueObject;
using UnityEngine;

namespace Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "Cd_BulletData", menuName = "Data/BulletData")]
    public class Cd_BulletData : ScriptableObject
    {
        public BulletData BulletData;
    }
}