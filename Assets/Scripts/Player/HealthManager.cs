using System;
using System.Collections;
using Damage.Base;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class HealthManager : MonoBehaviour
    {
        [SerializeField] private int health = 5;
        
        public int currentHealth => health;

        private AnimationManager _animationManager;
        private Movement3D _movement3D;

        

        private void Start()
        {
            _animationManager = GetComponentInChildren<AnimationManager>();
            _movement3D = GetComponent<Movement3D>();
            
            _animationManager.SetIsAlive(health > 0);
        }

        private void TakeDamage(int damage)
        {
            health -= damage;
            
            _animationManager.SetDamageAnimation();
            
            _movement3D.EnableMovement(false);

            if (health <= 0)
            {
                Die();
                return;
            }
            
            StartCoroutine(DisableMovement());
        }
        
        IEnumerator DisableMovement()
        {
            yield return new WaitForSeconds(1f);
            _movement3D.EnableMovement(true);
        }

        private void Die()
        {
            _animationManager.SetIsAlive(health > 0);
            
            _movement3D.EnableMovement(false);
            
            StartCoroutine(RestartLevel());
        }

        private IEnumerator RestartLevel()
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (health <= 0) return;
            
            var damageable = other.GetComponent<Damageable>();
            if (damageable != null)
            {
                var damage = damageable.DoDamage();
                damageable.PlayDamageSound();
                damageable.PlayDamageParticles(transform);
                TakeDamage(damage);
            }
        }
    }
}