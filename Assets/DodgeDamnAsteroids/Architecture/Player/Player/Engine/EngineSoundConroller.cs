using UnityEngine;

public class EngineSoundConroller : MonoBehaviour
{
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        PauseMenu.OnPauseActivatedEvent += Pause;
        PauseMenu.OnPauseDeactivatedEvent += Unpause;
    }
    private void OnDisable()
    {
        PauseMenu.OnPauseActivatedEvent -= Pause;
        PauseMenu.OnPauseDeactivatedEvent -= Unpause;
    }
    private void Update()
    {
        ChangePan();
    }
    private void ChangePan()
    {
        audioSource.panStereo = transform.position.x * 0.35f;
    }
    private void Unpause()
    {
        audioSource.UnPause();
    }
    private void Pause()
    {
        audioSource.Pause();
    }
}
