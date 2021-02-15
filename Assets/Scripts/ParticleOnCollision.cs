using UnityEngine;

public class ParticleOnCollision : MonoBehaviour
{
    [SerializeField] GameObject particlePrefab;
    [SerializeField] Collider2D collider;
    private void Start()
    {
        if (collider == null)
            collider = GetComponent<Collider2D>();

        collider.isTrigger = false;

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        var ball = other.gameObject.GetComponent<BallController>();
        if (ball != null)
            Instantiate(particlePrefab, ball.transform.position, ball.transform.rotation);
    }
}
