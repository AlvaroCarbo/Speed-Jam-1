using Damage.Interface;
using UnityEngine;
using UnityEngine.Serialization;

namespace Damage.Base
{
    public abstract class Damageable : MonoBehaviour, IDamageable
    {
        [SerializeField] internal int damage;
        [SerializeField] internal AudioClip damageSound;
        [SerializeField] internal ParticleSystem damageParticles;
        [SerializeField] internal float durationFX = 1f;
        [SerializeField] internal int particlesScale = 2;
        [SerializeField] internal Vector3 particlesOffset = Vector3.zero;
        public abstract int DoDamage();
        public abstract void PlayDamageSound();
        public abstract void PlayDamageParticles(Transform playerTransform);
        
    }
}