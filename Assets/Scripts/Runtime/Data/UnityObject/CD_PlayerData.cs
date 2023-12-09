using Runtime.Data.ValueObject;
using UnityEngine;

namespace Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_PlayerData", menuName = "Boomerang Warrior/CD_PlayerData", order = 0)]
    public class CD_PlayerData : ScriptableObject
    {
        public PlayerData PlayerData;
    }
}