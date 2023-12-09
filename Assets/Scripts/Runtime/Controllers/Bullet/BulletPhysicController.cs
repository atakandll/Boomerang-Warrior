using Runtime.Enums.ObjectPooling;
using Runtime.Interfaces;
using Runtime.Managers;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Controllers.Bullet
{
    public class BulletPhysicController : MonoBehaviour, IPushObject
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private BulletManager bulletManager;

        #endregion

        #endregion
        
        private void OnTriggerEnter(Collider other)
        {
            PushToPool(PoolObjectType.Bullet, transform.parent.gameObject);
        }

        public float TakeDamage()
        {
            return bulletManager.Damage;
        }

        public void PushToPool(PoolObjectType poolObjectType, GameObject obj)
        {
            PoolSignals.Instance.onReleaseObjectFromPool(poolObjectType, obj);
        }
        
    }
}