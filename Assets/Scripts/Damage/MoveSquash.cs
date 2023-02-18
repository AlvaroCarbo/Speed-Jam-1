using UnityEditor.U2D.Path;
using UnityEngine;

namespace Damage
{
    public class MoveSquash : MonoBehaviour
    {
        public float speed = 10f;
        public float maxYPosition = 5f;

        private bool _goingDown = true;
        
        [Header("Particles")]
        [SerializeField] private ParticleSystem _groundCollisionFX;
        [SerializeField] private int scale = 2;
        
        [Header("Audio")]
        [SerializeField] private AudioClip _groundCollisionSFX;

        // Update is called once per frame
        void Update()
        {
            var position = transform.position;
            if (_goingDown)
            {
                position.y -= speed * Time.deltaTime;
            }
            else
            {
                position.y += speed * Time.deltaTime;
                if (position.y >= maxYPosition)
                {
                    _goingDown = true;
                }
            }

            transform.position = position;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag($"Ground"))
            {
                // get the bottom position of the mesh bounds
                var colliderBounds = GetComponent<Collider>().bounds;
                var position = colliderBounds.center;
                position.y -= colliderBounds.extents.y;
                
                ParticlesManager.Instance.SpawnParticles(_groundCollisionFX, position, Quaternion.identity, 1, scale);
                AudioSource.PlayClipAtPoint(_groundCollisionSFX, position);
                _goingDown = false;
            }
        }
    }
}