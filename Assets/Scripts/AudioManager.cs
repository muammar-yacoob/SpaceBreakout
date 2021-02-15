using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake() => _audioSource = GetComponent<AudioSource>();

    private void PlaySFX(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }

}
