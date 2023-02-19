using System;
using Damage.Base;
using UnityEngine;

namespace Damage
{
    public class SquashDamage : Damageable
    {
        public override int DoDamage()
        {
            Debug.Log("Squash Damage" + damage);
           // GetComponent<SquashHelper>().SetTriggerToSquash();
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