using System;

namespace Runtime.Data.ValueObject
{
    [Serializable]
    public class PlayerData
    {
        public PlayerAnimationData PlayerAnimationData;

        public PlayerMovementData PlayerMovementData;

        public PlayerHealtData PlayerHealtData;

        public PlayerAttackData PlayerAttackData;
    }
}