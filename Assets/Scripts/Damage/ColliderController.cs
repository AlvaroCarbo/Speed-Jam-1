using Damage.Base;
using UnityEngine;

namespace Damage
{
    public class ColliderController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var damageable = other.GetComponent<Damageable>();
            if (damageable != null)
            {
                damageable.TakeDamage();
            }
        }
    }
}