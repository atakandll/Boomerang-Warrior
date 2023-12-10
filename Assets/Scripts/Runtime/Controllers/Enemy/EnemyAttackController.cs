using Runtime.Data.ValueObject;
using Runtime.Enums.ObjectPooling;
using Runtime.Managers;
using Runtime.Signals;
using UnityEngine;
using UnityEngine.AI;

namespace Runtime.Controllers.Enemy
{
    public class EnemyAttackController : MonoBehaviour
    {
        public bool IsActive { get; set; }

        [SerializeField]
        private GameObject spawnPosition;

        [SerializeField]
        private EnemyManager enemyManager;

        private EnemyAttackData _enemyAttackData;

        internal void SetData(EnemyAttackData enemyAttackData)
        {
            _enemyAttackData = enemyAttackData;
        }

        public void TriggerToAction()
        {
            if (!IsActive) return;

            Attack();
        }

        private void Attack()
        {
            GameObject bullet = PullFromPool(PoolObjectType.Bullet);

            bullet.transform.position = spawnPosition.transform.position;

            if (bullet.TryGetComponent(out BulletManager bulletmanager))
            {
                bulletmanager.Target = spawnPosition.transform;
            }
        }

        public GameObject PullFromPool(PoolObjectType poolObjectType)
        {
            return PoolSignals.Instance.onGetObjectFromPool(poolObjectType);
        }

    }
}