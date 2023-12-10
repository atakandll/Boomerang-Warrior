namespace Runtime.Interfaces
{
    public interface ISpawner
    {
        bool IsActivating { get; set; }
        void TriggerAction();
        void Spawn();
        void Reset();
    }
}