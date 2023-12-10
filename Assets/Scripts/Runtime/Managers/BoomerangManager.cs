using Runtime.Controllers.Boomerang;
using Runtime.Data.UnityObject;
using Runtime.Data.ValueObject;
using Runtime.Enums.ObjectPooling;
using Runtime.Interfaces;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class BoomerangManager : MonoBehaviour, IPushObject
    {
       public float Damage { get; set; }

        public string DataPath => "Data/Cd_BoomerangData";

        [SerializeField]
        private BoomerangMovementController boomerangMovementController;

        private BoomerangData _boomerangData;

        private float _timer;

        private void Awake()
        {
            GetData();
        }

        private void GetData() => _boomerangData = Resources.Load<Cd_BoomerangData>(DataPath).BoomerangData;

        public void SetData(Transform target)
        {
            Damage = _boomerangData.damage;

            boomerangMovementController.SetData(_boomerangData, target);
        }

        public void OnEnable()
        {
            ActiveteController();

            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onReset += OnReset;
        }

        private void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        public void OnDisable()
        {
            UnsubscribeEvents();
            DeactiveController();
        }

        private void Start()
        {
            TriggerController();

            SetSelfData();
        }

        private void SetSelfData()
        {
            Damage = _boomerangData.damage;

            Vector3 startPos = transform.position;

            boomerangMovementController.SetDataToStart(startPos);
        }

        public void TriggerController()
        {
            boomerangMovementController.TriggerAction();
        }

        public void ActiveteController()
        {
            boomerangMovementController.IsActive = true;
        }

        public void DeactiveController()
        {
            boomerangMovementController.IsActive = false;
        }

        private void OnReset()
        {
            PushToPool(PoolObjectType.Boomerang, gameObject);
        }

        public void PushToPool(PoolObjectType poolObjectType, GameObject obj)
        {
            PoolSignals.Instance.onReleaseObjectFromPool(poolObjectType, obj);
        }
    }
}