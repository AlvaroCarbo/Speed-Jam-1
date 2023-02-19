using UnityEngine;

public class ButtonController : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioClip buttonPressSound;
    
    private bool _isPressed;

    // private void OnTriggerEnter(Collider other)
    // {
    //     if (_isPressed) return;
    //     
    //     // var interact = other.GetComponent<InteractionLogic>();
    //     // Debug.Log(interact.isInteracting);
    //     
    //     // if (!interact.isInteracting) return;
    //
    //     _isPressed = true;
    //     PressButton();
    // }
    
    private void PressButton()
    {
        AudioManager.Instance.PlaySound(buttonPressSound);

        MusicManager.Instance.StopMusic();

        Invoke(nameof(PlayRunningMusic), 1f);
    }

    private void PlayRunningMusic()
    {
        MusicManager.Instance.PlayRunningMusic();
    }

    public void OnSelect()
    {
        // throw new System.NotImplementedException();
    }

    public void OnDeselect()
    {
        // throw new System.NotImplementedException();
    }

    public void OnInteract()
    {
        if (_isPressed) return;
        
        // var interact = other.GetComponent<InteractionLogic>();
        // Debug.Log(interact.isInteracting);
        
        // if (!interact.isInteracting) return;

        _isPressed = true;
        PressButton();
    }
}