using UnityEditor.U2D.Path;
using UnityEngine;

namespace Damage
{
    public class MoveSquash : MonoBehaviour
    {
        public float speed = 10f;
        [SerializeField] private float maxYPosition = 5f;

        private bool _goingDown = true;
        
        [Header("Particles")]
        [SerializeField] private ParticleSystem _groundCollisionFX;
        [SerializeField] private int scale = 2;
        
        [Header("Audio")]
        [SerializeField] private AudioClip _groundCollisionSFX;
        AudioSource _ownAudioSource;
        
        private void Start()
        {
            _ownAudioSource = GetComponent<AudioSource>();
            maxYPosition = transform.position.y;
        }

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
                _ownAudioSource.PlayOneShot(_groundCollisionSFX);
                _goingDown = false;
            }
        }
        
        private void OnDrawGizmos()
        {
            var colliderBounds = GetComponent<Collider>().bounds;
            var position = colliderBounds.center;
            position.y -= colliderBounds.extents.y;
            Gizmos.DrawWireSphere(position, 0.1f);
            
            RaycastHit hit;
            if (Physics.Raycast(position, Vector3.down, out hit))
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(hit.point, 0.5f);
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(position, hit.point);
            }
            Gizmos.DrawLine(position, new Vector3(position.x, maxYPosition, position.z));
            
            Gizmos.color = Color.green;
            // Draw sphere at the transform's position
            Gizmos.DrawSphere(transform.position, 0.5f);
            
        }
    }
}