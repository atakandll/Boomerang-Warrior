using Runtime.Data.ValueObject;
using UnityEngine;

namespace Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_BoomerangData", menuName = "Boomerang Warrior/CD_BoomerangData", order = 0)]
    public class CD_BoomerangData : ScriptableObject
    {
        public BoomerangData BoomerangData;
    }
}