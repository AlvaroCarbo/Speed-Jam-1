using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFXManager : MonoBehaviour
{
    public static PlayerFXManager Instance;
    
    [Header("FX")]
    [SerializeField] public ParticleSystem moveFX;
    [SerializeField] public ParticleSystem jumpFX;
    [SerializeField] public ParticleSystem landFX;
    [SerializeField] public ParticleSystem landFX2;
    
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

    public void PlayMoveFX()
    {
        var moveTransform = transform.rotation * Vector3.back;
        var particles = Instantiate(moveFX, transform.position, Quaternion.LookRotation(moveTransform));
        particles.transform.localScale = new Vector3(2, 2, 2);
        Destroy(particles.gameObject, moveFX.main.duration + 1f);
    }
    
    public void PlayJumpFX()
    {
        var jumpTransform = transform.rotation * Vector3.up;
        var particles = Instantiate(jumpFX, transform.position, Quaternion.LookRotation(jumpTransform));
        particles.transform.localScale = new Vector3(2, 2, 2);
        Destroy(particles.gameObject, jumpFX.main.duration + 1f);
    }
    
    public void PlayLandFX()
    {
        var landTransform = transform.rotation * Vector3.down;
        var particles = Instantiate(landFX, transform.position, Quaternion.LookRotation(landTransform));
        var particles2 = Instantiate(landFX2, transform.position, Quaternion.LookRotation(landTransform));
        particles.transform.localScale = new Vector3(2, 2, 2);
        particles2.transform.localScale = new Vector3(2, 2, 2);
        Destroy(particles.gameObject, landFX.main.duration + 1f);
        Destroy(particles2.gameObject, landFX2.main.duration + 1f);
    }
}
