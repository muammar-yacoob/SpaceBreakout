using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Animator))]
public class UIButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (animator != null)
            animator.speed = 0;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (animator != null)
            animator.speed = 1;
    }
}
