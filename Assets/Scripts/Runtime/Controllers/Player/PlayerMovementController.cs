using Runtime.Data.ValueObject;
using Unity.Mathematics;
using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public bool IsActive { get; set; }
        public float Direction { get => _direction; set => _direction = value; }
        public Vector3 JoystickDirection { get => _joystickDirection; set => _joystickDirection = value; }

        #endregion

        #region Serialized Variables

        [SerializeField] private new Rigidbody rigidbody;

        #endregion

        #region Private Variables
        
        private float _direction;
        private Vector3 _joystickDirection;
        private PlayerMovementData _playerMovementData;

        #endregion

        #endregion

        internal void SetData(PlayerMovementData playerMovementData, float camDirection)
        {
            _playerMovementData = playerMovementData;
        }

        internal void Move()
        {
            if (!IsActive) return;

            Quaternion targetRotation = Quaternion.LookRotation(JoystickDirection);
            rigidbody.MoveRotation(Quaternion.Slerp(rigidbody.rotation, targetRotation, _playerMovementData.TurnSpeed * Time.fixedDeltaTime));
            rigidbody.velocity = JoystickDirection.normalized * _playerMovementData.Speed;
        }
    }
}