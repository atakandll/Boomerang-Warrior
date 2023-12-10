using System;
using System.Collections.Generic;
using Runtime.Data.UnityObject;
using Runtime.Data.ValueObject;
using Runtime.Enums.ObjectPooling;
using Runtime.Enums.Spawn;
using Runtime.Interfaces;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class SpawnManager : MonoBehaviour
    {
        public SpawnData SpawnData { get; set; }

        public Dictionary<PoolObjectType, GameObject> spawnedContainer { get; set; }

        public string DataPath => "Data/Cd_SpawnData";

        private List<ISpawner> _activateable = new List<ISpawner>();

        public void Awake()
        {
            GetData();

            InitAllController();
        }

        public void GetData() => SpawnData = Resources.Load<Cd_SpawnData>(DataPath).SpawnData;

        private void InitAllController()
        {
            foreach (SpawnControllerType shopType in Enum.GetValues(typeof(SpawnControllerType)))
            {
                string shopName = "Scripts.Level.Controller." + shopType.ToString() + "Controller";

                ISpawner shop = (ISpawner)Activator.CreateInstance(System.Type.GetType(shopName), new object[] { this });

                _activateable.Add(shop);
            }
        }

        public void OnEnable()
        {
            SubscribeEvents();

            ActiveteController();
        }

        public void SubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize += OnLevelInitilize;
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;
        }

        public void UnsubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize -= OnLevelInitilize;
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;
        }

        public void OnDisable()
        {
            DeactiveController();

            UnsubscribeEvents();
        }

        private void OnLevelInitilize()
        {
            ActiveteController();
        }

        private void OnPlay()
        {
            Init();
        }

        private void Init() => TriggerController();

        public void TriggerController()
        {
            foreach (ISpawner activates in _activateable)
            {
                activates.TriggerAction();
            }
        }

        public void ActiveteController()
        {
            foreach (ISpawner activates in _activateable)
            {
                activates.IsActivating = true;
            }
        }

        public void DeactiveController()
        {
            foreach (ISpawner activates in _activateable)
            {
                activates.IsActivating = false;
            }
        }

        private void OnReset()
        {
            foreach (ISpawner activates in _activateable)
            {
                activates.Reset();
            }
            DeactiveController();
        }
    }
}