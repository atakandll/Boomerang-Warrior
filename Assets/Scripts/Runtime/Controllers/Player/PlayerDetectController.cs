using System;
using Runtime.Interfaces;
using Runtime.Managers;
using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerDetectController : MonoBehaviour
    {
        [SerializeField]
        private PlayerManager playerManager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IEnemyable enemy))
            {
                playerManager.HitEnemy(enemy.GetHitEnemy());
            }
        }
    }
}