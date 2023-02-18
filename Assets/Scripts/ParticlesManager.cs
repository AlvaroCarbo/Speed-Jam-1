using UnityEngine;

public class ParticlesManager : MonoBehaviour
{
    public static ParticlesManager Instance;
    private void Awake() 
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnParticles(ParticleSystem particles, Vector3 position, Quaternion rotation, float duration, int scale = 1)
    {
        var vfx  = Instantiate(particles, position, rotation);
        vfx.transform.localScale = new Vector3(scale, scale, scale);
        Destroy(vfx.gameObject, duration);
    }
}
