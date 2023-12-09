using Runtime.Data.ValueObject;
using Runtime.Enums.Player;
using Runtime.Managers;
using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerAnimationController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public bool IsActive { get; set; }


        #endregion

        #region Serialized Variables

        [SerializeField] private Animator animator;
        [SerializeField] private new Rigidbody rigidbody;
        [SerializeField] private PlayerManager playerManager;
        

        #endregion

        #region Private Variables

        private PlayerData _playerData;

        #endregion

        #endregion
        
        internal void SetData(PlayerData playerData)
        {
            _playerData = playerData;
        }
        public void OnDeadPlayer()
        {
            playerManager.OnDeadPlayer();
        }
        
        internal void SetIdleAnimation()
        {
            ChangeAnimationType(PlayerAnimationTypes.Idle);
        }
        
        internal void PlayDeadAnimation()
        {
            ChangeAnimationType(PlayerAnimationTypes.Dead);
        }
        
        public void ChangeAnimationType(PlayerAnimationTypes playeranimationtype)
        {
            animator.Play(playeranimationtype.ToString());
        }
        
        private void FixedUpdate()
        {
            PlayAnimation();
        }

        internal void PlayAnimation()
        {
            if(!IsActive) return;
            
            float currentSpeed = rigidbody.velocity.magnitude;
            float clampedValue = CalculationRationValue(currentSpeed, 0, _playerData.PlayerMovementData.Speed, 0, 1f);
            animator.SetFloat("Horizontal", clampedValue);
        }
        
        private float CalculationRationValue(float value, float inMin, float inMax, float outMin, float outMax)
        {

            float mappedNumber = (((value - inMin) * (outMax - outMin)) / (inMax - inMin)) + outMin;

            return mappedNumber;
        }
    }
}