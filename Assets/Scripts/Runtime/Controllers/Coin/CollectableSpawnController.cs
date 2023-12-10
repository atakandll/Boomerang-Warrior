using System.Collections.Generic;
using Runtime.Data.ValueObject;
using Runtime.Enums.ObjectPooling;
using Runtime.Extensions;
using Runtime.Interfaces;
using Runtime.Managers;
using Runtime.Signals;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class CollectableSpawnController : ISpawner, IPullObject, IPushObject
    {
        public bool IsActivating { get; set; }

        private List<GameObject> _spawnedObject = new();

        private SpawnManager _spawnManager;

        private CollectableSpawnData _collectableSpawnData;

        public CollectableSpawnController(SpawnManager spawnManager)
        {
            _spawnManager = spawnManager;

            _collectableSpawnData = _spawnManager.SpawnData.collectableSpawnData;
        }

        public void TriggerAction()
        {
            if (!IsActivating) return;

            for (int _counter = 0; _counter < _collectableSpawnData.spawnLimit; _counter++)
            {
                if (!IsActivating) break;

                Spawn();
            }
        }

        public void Spawn()
        {
            GameObject collectable = PullFromPool(PoolObjectType.SmallGold);

            _spawnedObject.Add(collectable);

            collectable.transform.position = SelfExtetions.GetRandomTopPosition(_collectableSpawnData.collectableSpawnZone) + new Vector3(0, 1, 0);
        }

        public GameObject PullFromPool(PoolObjectType poolObjectType)
        {
            return PoolSignals.Instance.onGetObjectFromPool(poolObjectType);
        }

        public void Reset()
        {
            foreach (var item in _spawnedObject)
            {
                PushToPool(PoolObjectType.SmallGold, item);
            }
        }

        public void PushToPool(PoolObjectType poolObjectType, GameObject obj)
        {
            PoolSignals.Instance.onReleaseObjectFromPool.Invoke(poolObjectType, obj);
        }
    }
}