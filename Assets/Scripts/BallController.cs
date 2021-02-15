using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] [Range(0.1f, 500f)] float Speed = 500;
    private Rigidbody2D rb;

    private void Awake() => rb = GetComponent<Rigidbody2D>();

    public void Kick() => rb.AddForce(Random.insideUnitCircle.normalized * Speed);
}