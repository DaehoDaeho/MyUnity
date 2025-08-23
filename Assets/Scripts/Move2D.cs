using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Move2D : MonoBehaviour
{
    public float accel = 30f;
    Rigidbody2D rb; float ax;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ax = Input.GetAxisRaw("Horizontal");
    } // -1, 0, 1

    void FixedUpdate()
    {
        rb.AddForce(new Vector2(ax * accel, 0f), ForceMode2D.Force);
    }
}
