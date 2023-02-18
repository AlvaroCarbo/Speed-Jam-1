using Damage.Base;
using UnityEngine;

namespace Damage
{
    public class GenericDamage : Damageable
    {
        public override void TakeDamage()
        {
            Debug.Log("Generic Damage");
        }
    }
}