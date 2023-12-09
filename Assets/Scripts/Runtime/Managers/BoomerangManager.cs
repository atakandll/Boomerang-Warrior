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
        #region Self Variables

        #region Public Variables

        public float Damage { get; set; }


        #endregion

        #region Serialized Variables
        
        [SerializeField] private BoomerangMovementController boomerangMovementController;

        #endregion

        #region Private Variables
        
        private float _timer;
        private BoomerangData _boomerangData;
        private string dataPath = "Data/CD_BoomerangData";


        #endregion

        #endregion
        
        private void Awake()
        {
            GetData();
        }

        private void GetData() => _boomerangData = Resources.Load<CD_BoomerangData>(dataPath).BoomerangData;

        public void SetData(Transform target)
        {
            Damage = _boomerangData.Damage;

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
            Damage = _boomerangData.Damage;

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