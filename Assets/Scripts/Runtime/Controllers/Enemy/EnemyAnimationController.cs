using Runtime.Data.ValueObject;
using Runtime.Enums.Enemy;
using Runtime.Managers;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Purchasing;

namespace Runtime.Controllers.Enemy
{
    public class EnemyAnimationController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public bool IsActive { get; set; }
        

        #endregion

        #region Serialized Variables

        [SerializeField] private Animator animator;
        [SerializeField] private EnemyManager enemyManager;
        
        #endregion

        #region Private Variables
        
        private EnemyAnimationData _enemyAnimationData;


        #endregion

        #endregion
        
        internal void SetData(EnemyAnimationData enemyAnimationData)
        {
            _enemyAnimationData = enemyAnimationData;
        }
        public void OnEnemyDead()
        {
            enemyManager.OnEnemyDead();
        }

        public void OnReadyToAttack()
        {
            TriggerAction();
            enemyManager.OnReadyToAttack();
        }

        public void PlayRunAnimation()
        {
            enemyManager.ActiveteController();

            ChangeAnimation(EnemyAnimationTypes.Run);
        }

        public void TriggerAction()
        {
            ChangeAnimation(EnemyAnimationTypes.Run);
        }
        public void PlayAttackAnim()
        {
            ChangeAnimation(EnemyAnimationTypes.Attack);
        }

        public void PlayDeadAnim()
        {
            ChangeAnimation(EnemyAnimationTypes.Dead);
        }

        private void ChangeAnimation(EnemyAnimationTypes types)
        {
            animator.Play(types.ToString());
        }
    }
}