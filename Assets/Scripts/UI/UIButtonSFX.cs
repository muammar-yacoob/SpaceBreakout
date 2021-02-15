using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator))]

public class UIButtonSFX : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] AudioSource SFXAudioSource;
    [SerializeField] AudioClip hoverSfx;
    [SerializeField] AudioClip clickSFX;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (SFXAudioSource != null && hoverSfx != null)
        {
            SFXAudioSource.PlayOneShot(hoverSfx);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (SFXAudioSource != null && clickSFX != null)
        {
            SFXAudioSource.PlayOneShot(clickSFX);
        }
    }
}
