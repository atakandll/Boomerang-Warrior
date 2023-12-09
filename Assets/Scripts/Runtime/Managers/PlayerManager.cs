using System;
using Runtime.Controllers.Player;
using Runtime.Data.UnityObject;
using Runtime.Data.ValueObject;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class PlayerManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerHealthController playerHealthController;
        [SerializeField] private PlayerMovementController playerMovementController;
        [SerializeField] private PlayerAnimationController playerAnimationController;
        [SerializeField] private PlayerAttackController playerAttackController;
        

        #endregion

        #region Private Variables

        private PlayerData _playerData;
        private float _camDirection;
        private string DataPath => "Data/CD_PlayerData";

        #endregion

        #endregion
        public void Awake()
        {
            GetData();

            SetData();
        }

        public void GetData() => _playerData = Resources.Load<CD_PlayerData>(DataPath).PlayerData;

        public void SetData()
        {
            playerMovementController.SetData(_playerData.PlayerMovementData, _camDirection);

            playerAnimationController.SetData(_playerData);

            playerHealthController.SetData(_playerData.PlayerHealthData);
        }

        private void OnEnable()
        {
            SubscribeEvents();
            SetData();
            ActiveteController();
        }

        private void SubscribeEvents()
        {
            InputSignals.Instance.onInputTouch += OnInputTouch;
            InputSignals.Instance.onInputReleased += OnInputReleased;
            PlayerSignals.Instance.onGetPlayerTransform += OnGetPlayerTransform;
        }

        private void UnsubscribeEvents()
        {
            InputSignals.Instance.onInputTouch -= OnInputTouch;
            InputSignals.Instance.onInputReleased -= OnInputReleased;
            PlayerSignals.Instance.onGetPlayerTransform -= OnGetPlayerTransform;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
            DeactiveController();
        }
          private void Start()
        {
            TriggerController();

            _camDirection = CameraSignals.Instance.onSpawnPlayer.Invoke(gameObject);
        }

        private void OnInputTouch(float direction, Vector3 joystick)
        {
            playerMovementController.Direction = direction;

            playerMovementController.JoystickDirection = joystick;

            playerMovementController.Move();
        }

        private void OnInputReleased()
        {
        }

        public void TriggerController()
        {
            playerAnimationController.SetIdleAnimation();
        }

        public void ActiveteController()
        {
            playerMovementController.IsActive = true;

            playerAnimationController.IsActive = true;

            playerAttackController.IsActive = true;
        }

        public void DeactiveController()
        {
            playerMovementController.IsActive = false;

            playerAnimationController.IsActive = false;

            playerAttackController.IsActive = false;
        }

        internal void OnHealthChange(float healthValue)
        {
            UISignals.Instance.onHealth?.Invoke(healthValue);
        }

        internal void PlayerDead()
        {
            DeactiveController();

            playerAnimationController.PlayDeadAnimation();
        }

        internal void OnDeadPlayer()
        {
            CoreGameSignals.Instance.onFail?.Invoke();
        }
        internal void HitEnemy(GameObject enemyObject)
        {
            playerAttackController.TargetGameObject = enemyObject;

            playerAttackController.TriggerAction();
        }
        
        internal void HitDamage(float damage)
        {
            playerHealthController.SetDamage((int)damage);

            playerHealthController.OnTakeDamage();
        }
        
        private Transform OnGetPlayerTransform()
        {
            return transform;
        }
    }
}