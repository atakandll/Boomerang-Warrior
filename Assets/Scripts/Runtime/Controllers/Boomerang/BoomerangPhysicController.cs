using Runtime.Enums.ObjectPooling;
using Runtime.Managers;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Controllers.Boomerang
{
    public class BoomerangPhysicController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private BoomerangManager boomerangManager; 

        #endregion

        #endregion
        
        private void OnTriggerEnter(Collider other)
        {
            PushToPool(PoolObjectType.Bullet, transform.parent.gameObject);
        }

        public float TakeDamage()
        {
            return boomerangManager.Damage;
        }

        public void PushToPool(PoolObjectType poolObjectType, GameObject obj)
        {
            PoolSignals.Instance.onReleaseObjectFromPool(poolObjectType, obj);
        }
    }
}