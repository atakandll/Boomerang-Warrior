using Runtime.Controllers.Bullet;
using Runtime.Enums.ObjectPooling;
using Runtime.Interfaces;
using Runtime.Managers;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerPhysicController : MonoBehaviour, IPushObject
    {
        #region Self Variables

        #region Serialized Variables
        
        [SerializeField] private PlayerManager playerManager;
        

        #endregion

        #endregion
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BulletPhysicController bulletPyhsicController))
            {
                playerManager.HitDamage(bulletPyhsicController.TakeDamage());
            }

            if (other.CompareTag("Coin"))
            {
                //playerManager.HitCoin();

                PushToPool(PoolObjectType.Coin, other.transform.parent.gameObject);
            }
        }

        public void PushToPool(PoolObjectType poolObjectType, GameObject obj)
        {
            PoolSignals.Instance.onReleaseObjectFromPool(poolObjectType, obj);
        }
    }
}