using Runtime.Data.ValueObject;
using Runtime.Managers;
using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerHealthController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerManager playerManager;

        #endregion

        #region Private Variables
        
        private float _health;
        private float _maxHealth;
        private float _damage;
        private float _deadHealth;

        #endregion

        #endregion

        internal void SetData(PlayerHealthData playerHealthData)
        {
            _maxHealth = playerHealthData.MaxHealth;
            _health = _maxHealth;
            OnHealthChange(_health);
        }

        internal void SetDamage(int damage)
        {
            _damage = damage;
            _deadHealth = _maxHealth / damage;
        }

        public void OnTakeDamage()
        {
            _health -= _damage;
            
            if (_health <= 0)
            {
                OnHealthChange(_health);
                playerManager.PlayerDead();
                return;
            }
            OnHealthChange(_health);
        }

        private void OnHealthChange(float healthValue)
        {
            playerManager.OnHealthChange(healthValue);
        }
    }
}