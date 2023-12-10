using Runtime.Data.ValueObject;
using Runtime.Enums.Enemy;
using Runtime.Managers;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Purchasing;

namespace Runtime.Controllers.Enemy
{
    public class EnemyAnimationController : MonoBehaviour
    { public bool IsActive { private get; set; }

        [SerializeField]
        private NavMeshAgent navMeshAgent;

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private EnemyManager enemyManager;

        private EnemyAnimationData _enemyAnimationData;

        internal void SetData(EnemyAnimationData enemyAnimationData)
        {
            _enemyAnimationData = enemyAnimationData;
        }

        public void OnEnemyDying()
        {
            enemyManager.OnEnemyDying();
        }

        public void OnReadyToAttack()
        {
            TriggerAction();
            enemyManager.OnReadyToAttack();
        }

        public void PlayRunAnimation()
        {
            enemyManager.ActiveteController();

            ChangeAnimation(EnemyAnimationType.Run);
        }

        public void TriggerAction()
        {
            ChangeAnimation(EnemyAnimationType.Run);
        }

        public void PlayAttackAnimation()
        {
            ChangeAnimation(EnemyAnimationType.Attack);
        }

        public void PlayDyingAnimation()
        {

            ChangeAnimation(EnemyAnimationType.Die);
        }

        private void ChangeAnimation(EnemyAnimationType enemyAnimationType)
        {
            animator.Play(enemyAnimationType.ToString());
        }
    }
}