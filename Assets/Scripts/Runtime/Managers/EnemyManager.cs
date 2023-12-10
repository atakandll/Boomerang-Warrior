using System;
using Runtime.Controllers.Enemy;
using Runtime.Data.UnityObject;
using Runtime.Data.ValueObject;
using Runtime.Enums.ObjectPooling;
using Runtime.Interfaces;
using Runtime.Signals;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Runtime.Managers
{
    public class EnemyManager : MonoBehaviour, IPushObject
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private EnemyMovementController enemyMovementController;
        [SerializeField] private EnemyAnimationController enemyAnimationController;
        [SerializeField] private EnemyAttackController enemyAttackController;
        [SerializeField] private EnemyPhysicController enemyPhysicController;
        

        #endregion

        #region Private Variables

        private EnemyData _enemyData;
        private Transform _playerTransform;
        private string DataPath => "Data/CD_EnemyData";

        #endregion

        #endregion

        private void Awake()
        {
            GetData();
            SetData();
        }
        public void GetData() => _enemyData = Resources.Load<CD_EnemyData>(DataPath).EnemyData;

        public void SetData()
        {
            enemyMovementController.SetData(_enemyData.EnemyMovementData);
            enemyAnimationController.SetData(_enemyData.EnemyAnimationData);
            enemyAttackController.SetData(_enemyData.EnemyAttackData);
        }
        public void OnEnable()
        {
            ActiveteController();
        }

        public void OnDisable()
        {
            DeactiveController();
        }

        private void Start()
        {
            TriggerController();
        }

        public void TriggerController()
        {
            enemyPhysicController.OpenCollider();

            enemyAnimationController.TriggerAction();
        }

        public void ActiveteController()
        {
            enemyMovementController.IsActive = true;
            enemyAnimationController.IsActive = true;
            enemyAttackController.IsActive = true;
        }

        public void DeactiveController()
        {
            enemyMovementController.IsActive = false;
            enemyAnimationController.IsActive = false;
            enemyAttackController.IsActive = false;
        }

        internal void EnterDetectArea()
        {
            enemyAnimationController.PlayAttackAnim();
        }

        internal void OnReadyToAttack()
        {
            enemyAttackController.TriggerToAction();

            ActiveteController();
        }

        internal void OnHitBoomerang()
        {
            enemyPhysicController.CloseCollider();

            enemyMovementController.IsActive = false;

            enemyAnimationController.PlayDeadAnim();
        }

        internal void OnEnemyDead()
        {

            PushToPool(PoolObjectType.Enemy, gameObject);
        }

        public Transform GetPlayerTransform()
        {
            return PlayerSignals.Instance.onGetPlayerTransform?.Invoke();
        }

        public void PushToPool(PoolObjectType poolObjectType, GameObject obj)
        {
            PoolSignals.Instance.onReleaseObjectFromPool(poolObjectType, obj);
        }
    }
}