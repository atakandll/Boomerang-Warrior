using Runtime.Enums.ObjectPooling;
using Runtime.Interfaces;
using Runtime.Managers;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerAttackController : MonoBehaviour, IPullObject
    {
        [SerializeField]
        private GameObject spawnPointForBoomerang;

        private float _timer;

        public bool IsActive { get; set; }

        public  GameObject TargetObject { get; set; }

        public void TriggerAction()
        {
            Attack();
        }

        private void Attack()
        {
            if (!IsActive) return;

            GameObject boomerang = PullFromPool(PoolObjectType.Boomerang);

            Vector3 HorizontalOffset = new Vector3(0, 1, 0);

            boomerang.transform.position = transform.position + HorizontalOffset;

            if (boomerang.TryGetComponent(out BoomerangManager boomerangManager))
            {
                boomerangManager.SetData(TargetObject.transform);
            }
        }
        public GameObject PullFromPool(PoolObjectType poolObjectType)
        {
            return PoolSignals.Instance.onGetObjectFromPool(poolObjectType);
        }
    }
}