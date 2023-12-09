using System;

namespace Runtime.Data.ValueObject
{
    [Serializable]
    public struct PlayerData
    {
        public PlayerAnimationData PlayerAnimationData;
        public PlayerAttackData PlayerAttackData;
        public PlayerMovementData PlayerMovementData;
        public PlayerHealthData PlayerHealthData;
    }
}