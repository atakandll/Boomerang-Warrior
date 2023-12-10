using System.Collections.Generic;
using Runtime.Data.ValueObject;
using Runtime.Enums.ObjectPooling;
using Runtime.Managers;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Controllers.Coin
{
    public class CoinSpawnController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public bool IsActivating { get; set; }
        
        #endregion

        #region Private Variables

        private List<GameObject> _spawnedObject = new List<GameObject>();
        private SpawnManager _spawnManager;
        private CoinSpawnData _coinSpawnData;

        #endregion

        #endregion
        
        public CoinSpawnController(SpawnManager spawnManager)
        {
            _spawnManager = spawnManager;

            _coinSpawnData = _spawnManager.SpawnData.CoinSpawnData;
        }

        public void TriggerAction()
        {
            if (!IsActivating) return;

            for (int _counter = 0; _counter < _coinSpawnData.SpawnLimit; _counter++)
            {
                if (!IsActivating) break;

                Spawn();
            }
        }

        public void Spawn()
        {
            GameObject collectable = PullFromPool(PoolObjectType.Coin);

            _spawnedObject.Add(collectable);

            collectable.transform.position = GetRandomTopPosition(_coinSpawnData.CoinSpawnZone) + new Vector3(0, 1, 0);
        }
        
        private Vector3 GetRandomTopPosition(GameObject enemySpawnZone)
        {
            float x = enemySpawnZone.transform.localScale.x;
            float y = enemySpawnZone.transform.localScale.y;
            float z = enemySpawnZone.transform.localScale.z;

            Vector3 topPosition = enemySpawnZone.transform.position + new Vector3(0, y / 2f, 0);

            Vector3 randomTopPosition = new Vector3(
                Random.Range(topPosition.x - x / 2f, topPosition.x + x / 2f),
                topPosition.y,
                Random.Range(topPosition.z - z / 2f, topPosition.z + z / 2f)
            );

            return randomTopPosition;
        }

        public GameObject PullFromPool(PoolObjectType poolObjectType)
        {
            return PoolSignals.Instance.onGetObjectFromPool(poolObjectType);
        }

        public void Reset()
        {
            foreach (var item in _spawnedObject)
            {
                PushToPool(PoolObjectType.Coin, item);
            }
        }

        public void PushToPool(PoolObjectType poolObjectType, GameObject obj)
        {
            PoolSignals.Instance.onReleaseObjectFromPool.Invoke(poolObjectType, obj);
        }
    }
}