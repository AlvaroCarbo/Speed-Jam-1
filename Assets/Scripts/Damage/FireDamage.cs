using Damage.Base;
using UnityEngine;

namespace Damage
{
    public class FireDamage : Damageable
    {
        public override void TakeDamage()
        {
            Debug.Log("Fire Damage");
        }
    }
}