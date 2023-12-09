using System;
using Runtime.Controllers.Boomerang;
using Runtime.Controllers.Player;
using Runtime.Interfaces;
using Runtime.Managers;
using UnityEngine;

namespace Runtime.Controllers.Enemy
{
    public class EnemyPhysicController : MonoBehaviour, IEnemyable
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private EnemyManager enemyManager;
        [SerializeField] new Collider collider;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerDetectController playerDetectController))
            {
                enemyManager.EnterDetectArea();
            }
            if (other.TryGetComponent(out BoomerangPhysicController boomerangPhysicController))
            {
                enemyManager.OnHitBoomerang();
            }
        }
        public GameObject GetHitEnemy()
        {
            return transform.parent.gameObject;
        }

        public void CloseCollider()
        {
            collider.enabled = false;
        }

        public void OpenCollider()
        {
            collider.enabled = true;
        }
    }
}