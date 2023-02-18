using Damage.Interface;
using UnityEngine;
using UnityEngine.Serialization;

namespace Damage.Base
{
    public abstract class Damageable : MonoBehaviour, IDamageable
    {
        public int damage;
        public abstract void TakeDamage();
    }
}