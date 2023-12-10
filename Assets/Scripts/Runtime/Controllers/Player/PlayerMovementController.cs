using Runtime.Data.ValueObject;
using Unity.Mathematics;
using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        public bool IsActive { get; set; }
        public float Diraction { get => _diraction; set => _diraction = value; }
        public Vector3 JoystickDirection { get => _joystickDirection; set => _joystickDirection = value; }

        private float _diraction;

        private Vector3 _joystickDirection;

        private PlayerMovementData _playerMovementData;

        [SerializeField]
        private new Rigidbody rigidbody;

        internal void SetData(PlayerMovementData playerMovementData, float camDiraction)
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