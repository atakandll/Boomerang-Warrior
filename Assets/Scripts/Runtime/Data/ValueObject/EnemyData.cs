using System;

namespace Runtime.Data.ValueObject
{
    [Serializable]
    public struct EnemyData
    {
        public EnemyMovementData EnemyMovementData;
        public EnemyAnimationData EnemyAnimationData;
        public EnemyAttackData EnemyAttackData;
    }
}