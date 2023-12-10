using Runtime.Data.ValueObject;
using Runtime.Managers;
using UnityEngine;
using UnityEngine.AI;

namespace Runtime.Controllers.Enemy
{
    public class EnemyMovementController : MonoBehaviour
    {
        public bool IsActive { get; set; }

        [SerializeField]
        private NavMeshAgent agent;

        [SerializeField]
        private EnemyManager enemyManager;

        private EnemyMovementData _enemyMovementData;

        private Transform _playerTransform;

        internal void SetData(EnemyMovementData enemyMovementData)
        {
            _enemyMovementData = enemyMovementData;
        }

        private void Update()
        {
            if (!IsActive)
            {
                agent.ResetPath();

                return;
            }

            _playerTransform = enemyManager.GetPlayerTransform();

            StartMovement();
        }

        public void StartMovement()
        {

            agent.speed = _enemyMovementData.speed;

            agent.SetDestination(_playerTransform.position);
        }

    }
}