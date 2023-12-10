using System.Collections.Generic;
using System.Threading.Tasks;
using Runtime.Data.ValueObject;
using Runtime.Enums.ObjectPooling;
using Runtime.Interfaces;
using Runtime.Managers;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Controllers.Enemy
{
    public class EnemySpawnController : ISpawner, IPushObject, IPullObject
    {
        #region Self Variables

        #region Public Variables

        public bool IsActivating { get; set; }
        
        #endregion

        #region Private Variables

        private List<GameObject> _spawnedObject = new List<GameObject>();
        private SpawnManager _spawnManager;
        private EnemySpawnData _enemySpawnData;

        #endregion

        #endregion

        public EnemySpawnController(SpawnManager spawnManager)
        {
            _spawnManager = spawnManager;
            _enemySpawnData = spawnManager.SpawnData.EnemySpawnData;
        }
        public void TriggerAction()
        {
            if (!IsActivating) return;

            SpawnFactory();
        }

        private async void SpawnFactory()
        {
            int millisecond = _enemySpawnData.SpawnRange * 1000;

            for (int i = 0; i < _enemySpawnData.SpawnLimit; i++)
            {
                if (!IsActivating) break;

                await Task.Delay(millisecond);

                Spawn();
            }
        }

        public void Spawn()
        {
            GameObject enemy = PullFromPool(PoolObjectType.Enemy);

            _spawnedObject.Add(enemy);

            enemy.transform.position = GetRandomTopPosition(_enemySpawnData.EnemySpawnZone);
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
                PushToPool(PoolObjectType.Enemy, item);
            }
        }

        public void PushToPool(PoolObjectType poolObjectType, GameObject obj)
        {
            PoolSignals.Instance.onReleaseObjectFromPool.Invoke(poolObjectType, obj);
        }

    }
}