using Runtime.Data.ValueObject;
using UnityEngine;

namespace Runtime.Data.UnityObject
{
    [CreateAssetMenu(fileName = "Cd_PlayerData", menuName = "Data/PlayerData")]
    public class Cd_PlayerData : ScriptableObject
    {
        public PlayerData PlayerData;
    }
}