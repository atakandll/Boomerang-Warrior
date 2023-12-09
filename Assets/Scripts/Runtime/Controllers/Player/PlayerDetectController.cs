using System;
using Runtime.Interfaces;
using Runtime.Managers;
using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerDetectController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerManager playerManager;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEnemyable enemy))
            {
                playerManager.HitEnemy(enemy.GetHitEnemy());
            }
        }
    }
}