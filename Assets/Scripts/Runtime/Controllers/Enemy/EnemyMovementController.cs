using Runtime.Data.ValueObject;
using Runtime.Managers;
using UnityEngine;
using UnityEngine.AI;

namespace Runtime.Controllers.Enemy
{
    public class EnemyMovementController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public bool IsActive { get; set; }
        

        #endregion

        #region Serialized Variables

        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private EnemyManager enemyManager;
        
        #endregion

        #region Private Variables
        
        private EnemyMovementData _enemyMovementData;
        private Transform _playerTransform;
        
        #endregion
        
        #endregion
        
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

            agent.speed = _enemyMovementData.Speed;

            agent.SetDestination(_playerTransform.position);
        }

    }
}