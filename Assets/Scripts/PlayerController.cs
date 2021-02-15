using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] [Range(1, 10)] private float maxSpeed;
    float speed;

    private float sensitivity = 0.1f;
    float horizontal;


    void Update()
    {
        speed = Mathf.Abs(transform.position.x) > 2f ?
            maxSpeed / 3 : maxSpeed;

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(horizontal) >= sensitivity)
            transform.Translate(horizontal * Vector2.right * speed * Time.deltaTime);
    }
}