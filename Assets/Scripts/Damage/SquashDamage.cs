using Damage.Base;
using UnityEngine;

namespace Damage
{
    public class SquashDamage : Damageable
    {
        public override void TakeDamage()
        {
            Debug.Log("Squash Damage" + damage);
        }
    }
}