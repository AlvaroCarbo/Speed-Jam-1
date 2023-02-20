using UnityEngine;
using UnityEngine.Events;

public class ButtonController : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioClip buttonPressSound;
    
    private bool _isPressed;
    
    [SerializeField] private DoorControl doorControl;
    
    [SerializeField] private UnityEvent evento;

    [SerializeField] private UnityEvent onSelect;
    [SerializeField] private UnityEvent onDeselect;

    private void PressButton()
    {
        AudioManager.Instance.PlaySound(buttonPressSound);

        MusicManager.Instance.StopMusic();

        Invoke(nameof(PlayRunningMusic), 1f);
        
        Invoke(nameof(OpenDoor), 1f);
    }

    private void PlayRunningMusic()
    {
        MusicManager.Instance.PlayRunningMusic();
    }
    
    private void OpenDoor()
    {
        doorControl.OpenDoor();
    }

    public void OnSelect()
    {
        onSelect.Invoke();
    }

    public void OnDeselect()
    {
        onDeselect.Invoke();
    }

    public void OnInteract()
    {
        if (_isPressed) return;
        _isPressed = true;
        
        PressButton();
        evento.Invoke();
    }
}