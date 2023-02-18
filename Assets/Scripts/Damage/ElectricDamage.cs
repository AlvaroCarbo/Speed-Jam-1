using Damage.Base;
using UnityEngine;

namespace Damage
{
    public class ElectricDamage : Damageable
    {
        public override void TakeDamage()
        {
            Debug.Log("Electric Damage");
        }
    }
}