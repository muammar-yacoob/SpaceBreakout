using UnityEngine;
[RequireComponent(typeof(Collider2D))]

public class FatalObject : MonoBehaviour
{
    [SerializeField] uint damageAmount = 1;
    [SerializeField] AudioSource SFXAudioSource;
    [SerializeField] AudioClip sfx;
    GamePlay gamePlay;

    private void Start()
    {
        GetComponent<Collider2D>().isTrigger = false;
        gamePlay = GamePlay.Instance;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        var ball = other.gameObject.GetComponent<BallController>();
        if (ball == null)
            return;


        gamePlay.DealDamage(damageAmount);

        if (SFXAudioSource != null && sfx != null)
            SFXAudioSource.PlayOneShot(sfx);
    }
}