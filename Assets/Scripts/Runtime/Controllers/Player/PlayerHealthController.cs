using Runtime.Data.ValueObject;
using Runtime.Managers;
using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerHealthController : MonoBehaviour
    {
        [SerializeField]
        private PlayerManager playerManager;

        private float _health;
        private int _deadHealt;
        private int _maxHealt;
        private int _damage;

        internal void SetData(PlayerHealtData playerHealtData)
        {
            _maxHealt = playerHealtData.MaxHealth;
            _health = _maxHealt;
            OnHealthUpdate(_health);
        }

        internal void SetDamage(int damage)
        {
            _damage = damage;

            _deadHealt = _maxHealt / damage;
        }

        public void OnTakeDamage()
        {
            _health -= _damage;

            if (_health <= 0)
            {
                OnHealthUpdate(_health);

                playerManager.PlayerDead();

                return;
            }

            OnHealthUpdate(_health);
        }

        private void OnHealthUpdate(float healthValue)
        {
            playerManager.OnHealtDecrase(healthValue);
        }
    }
}