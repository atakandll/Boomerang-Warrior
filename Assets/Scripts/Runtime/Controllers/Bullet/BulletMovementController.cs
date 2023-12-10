using Runtime.Data.ValueObject;
using UnityEngine;

namespace Runtime.Controllers.Bullet
{
    public class BulletMovementController : MonoBehaviour
    {
        public bool IsActive { get; set; }

        public BulletData BulletData { get; set; }

        public Transform Target { get; set; }

        [SerializeField]
        private Rigidbody bulletRigdbody;

        public void TriggerAction()
        {
            if (!IsActive) return;

            MoveAsFireBal();
        }

        private void MoveAsFireBal()
        {
            bulletRigdbody.AddForce(Target.forward * BulletData.Speed, ForceMode.Impulse);
        }
    }
}