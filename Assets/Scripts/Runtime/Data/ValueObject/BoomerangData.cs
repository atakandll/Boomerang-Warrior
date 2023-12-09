using System;

namespace Runtime.Data.ValueObject
{
    [Serializable]
    public struct BoomerangData
    {
        public int Damage;
        public int ArrivalTime;
        public int Rotations;
        public float Duration;
    }
}