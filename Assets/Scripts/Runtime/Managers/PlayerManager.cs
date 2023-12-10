using System;
using Runtime.Controllers.Player;
using Runtime.Data.UnityObject;
using Runtime.Data.ValueObject;
using Runtime.Interfaces;
using Runtime.Signals;
using UnityEngine;

namespace Runtime.Managers
{
    public class PlayerManager : MonoBehaviour, IManagable
    {
         [SerializeField]
        private PlayerAttackController playerAttackController;

        [SerializeField]
        private PlayerHealthController playerHealthController;

        [SerializeField]
        private PlayerMovementController playerMovementController;

        [SerializeField]
        private PlayerAnimationController playerAnimationController;

        private PlayerData _playerData;

        private float _camDiraction;

        public string DataPath => "Data/Cd_PlayerData";

        public void Awake()
        {
            GetData();

            SetData();
        }

        public void GetData() => _playerData = Resources.Load<Cd_PlayerData>(DataPath).PlayerData;

        public void SetData()
        {
            playerMovementController.SetData(_playerData.PlayerMovementData, _camDiraction);

            playerAnimationController.SetData(_playerData);

            playerHealthController.SetData(_playerData.PlayerHealtData);
        }

        public void OnEnable()
        {
            SubscribeEvents();

            SetData();

            ActiveteController();
        }

        public void SubscribeEvents()
        {
            InputSignals.Instance.onInputTouch += OnInputTouch;

            InputSignals.Instance.onInputReleased += OnInputReleased;

            PlayerSignals.Instance.onGetPlayerTransform += OnGetPlayerTransform;
        }

        public void UnsubscribeEvents()
        {
            InputSignals.Instance.onInputTouch -= OnInputTouch;

            InputSignals.Instance.onInputReleased -= OnInputReleased;

            PlayerSignals.Instance.onGetPlayerTransform -= OnGetPlayerTransform;
        }

        public void OnDisable()
        {
            DeactiveController();

            UnsubscribeEvents();
        }

        private void Start()
        {
            TriggerController();

            _camDiraction = CameraSignals.Instance.onSpawnPlayer.Invoke(gameObject);
        }

        private void OnInputTouch(float diraction, Vector3 joystick)
        {
            
            playerMovementController.Diraction = diraction;

            playerMovementController.JoystickDirection = joystick;

            playerMovementController.Move();
        }

        private void OnInputReleased()
        {

        }

        public void TriggerController()
        {
            playerAnimationController.SetDefaultAnimation();
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

        internal void OnHealtDecrase(float healthValue)
        {
            UISignals.Instance.onHealthDecrase?.Invoke(healthValue);
        }

        internal void PlayerDead()
        {
            DeactiveController();

            playerAnimationController.PlayDadAnimation();
        }

        internal void OnDeadPlayer()
        {
            CoreGameSignals.Instance.onFail?.Invoke();
        }

        internal void HitEnemy(GameObject enemyObject)
        {
            playerAttackController.TargetObject = enemyObject;

            playerAttackController.TriggerAction();
        }

        internal void HitDamager(float damage)
        {
            playerHealthController.SetDamage((int)damage);

            playerHealthController.OnTakeDamage();
        }

        internal void HitCoin()
        {
            ScoreSignals.Instance.onScoreTaken?.Invoke();
        }

        private Transform OnGetPlayerTransform()
        {
            return transform;
        }
    }
}