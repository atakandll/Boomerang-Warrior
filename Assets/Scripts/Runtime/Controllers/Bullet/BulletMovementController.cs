using Runtime.Data.ValueObject;
using UnityEngine;

namespace Runtime.Controllers.Bullet
{
    public class BulletMovementController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public bool IsActive { get; set; }
        public BulletData BulletData { get; set; }
        public Transform Target { get; set; }

        #endregion

        #region Serialized Variables

        [SerializeField] private Rigidbody bulletRigidbody;

        #endregion

        #endregion

        public void TriggerAction()
        {
            if(!IsActive) return;
            
            MoveAsFireBall();
        }

        private void MoveAsFireBall()
        {
            bulletRigidbody.AddForce(Target.forward*BulletData.Speed, ForceMode.Impulse);
        }
    }
}