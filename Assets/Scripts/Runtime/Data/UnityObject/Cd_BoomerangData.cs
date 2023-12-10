using Runtime.Data.ValueObject;
using UnityEngine;

namespace Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "Cd_BoomerangData", menuName = "Data/BoomerangData")]
    public class Cd_BoomerangData : ScriptableObject
    {
        public BoomerangData BoomerangData;
    }
}