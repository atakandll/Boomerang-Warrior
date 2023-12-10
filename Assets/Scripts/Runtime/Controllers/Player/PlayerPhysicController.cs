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
        [SerializeField]
        private PlayerManager playerManager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BulletPhysicController bulletPyhsicController))
            {
                playerManager.HitDamager(bulletPyhsicController.TakeDamage());
            }

            if (other.CompareTag("Coin"))
            {
                playerManager.HitCoin();

                PushToPool(PoolObjectType.SmallGold, other.transform.parent.gameObject);
            }
        }

        public void PushToPool(PoolObjectType poolObjectType, GameObject obj)
        {
            PoolSignals.Instance.onReleaseObjectFromPool(poolObjectType, obj);
        }
    }
}