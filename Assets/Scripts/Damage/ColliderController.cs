using Damage.Base;
using UnityEngine;

namespace Damage
{
    public class ColliderController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Triggered");
        }
    }
}