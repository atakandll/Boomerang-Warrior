namespace Runtime.Interfaces
{
    public interface IManagable
    {
        string DataPath { get; }

        void Awake();

        void GetData();

        void SetData();

        void OnEnable();

        void SubscribeEvents();

        void UnsubscribeEvents();

        void OnDisable();

        void TriggerController();

        void ActiveteController();

        void DeactiveController();
    }
}