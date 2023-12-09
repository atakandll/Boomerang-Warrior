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
        #region Self Variables

        #region Public Variables

        public bool IsActive { get; set; }
        

        #endregion

        #region Serialized Variables

        [SerializeField] private GameObject spawnPosition;
        [SerializeField] private EnemyManager enemyManager;
        
        #endregion

        #region Private Variables
        
        private EnemyAttackData _enemyAttackData;
        
        #endregion
        
        #endregion
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