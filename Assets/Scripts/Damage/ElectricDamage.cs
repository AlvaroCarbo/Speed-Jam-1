using Damage.Base;
using UnityEngine;

namespace Damage
{
    public class ElectricDamage : Damageable
    {
        public override int DoDamage()
        {
            Debug.Log("Electric Damage");
            return damage;
        }

        public override void PlayDamageSound()
        {
            AudioManager.Instance.PlaySound(damageSound);
        }

        public override void PlayDamageParticles(Transform playerTransform)
        {
            ParticlesManager.Instance.SpawnParticles(damageParticles, playerTransform.position + particlesOffset,
                playerTransform.rotation, durationFX, particlesScale);
        }
    }
}