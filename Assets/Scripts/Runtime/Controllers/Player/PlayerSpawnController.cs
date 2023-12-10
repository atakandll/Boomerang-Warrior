using System.Collections.Generic;
using Runtime.Data.ValueObject;
using Runtime.Enums.ObjectPooling;
using Runtime.Interfaces;
using Runtime.Managers;
using Runtime.Signals;
using UnityEngine;

namespace Scripts.Level.Controller
{
    public class PlayerSpawnController : ISpawner, IPushObject, IPullObject
    {
        public bool IsActivating { get; set; }

        private SpawnManager _spawnManager;

        private PlayerSpawnData _playerSpawnData;

        private List<GameObject> _spawnedObject = new();

        public PlayerSpawnController(SpawnManager spawnManager)
        {
            _spawnManager = spawnManager;

            _playerSpawnData = _spawnManager.SpawnData.playerSpawnData;
        }

        public void TriggerAction()
        {
            if (!IsActivating) return;

            Spawn();
        }

        public void Spawn()
        {
            GameObject player = PullFromPool(PoolObjectType.Player);

            player.transform.position = Vector3.zero;

            _spawnedObject.Add(player);
        }

        public GameObject PullFromPool(PoolObjectType poolObjectType)
        {
            return PoolSignals.Instance.onGetObjectFromPool(poolObjectType);
        }

        public void Reset()
        {
            foreach (var item in _spawnedObject)
            {
                PushToPool(PoolObjectType.Player, item);
            }
        }

        public void PushToPool(PoolObjectType poolObjectType, GameObject obj)
        {
            PoolSignals.Instance.onReleaseObjectFromPool.Invoke(poolObjectType, obj);
        }
    }
}