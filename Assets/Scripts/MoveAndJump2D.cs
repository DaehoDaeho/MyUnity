using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveAndJump2D : MonoBehaviour
{
    public float accel = 30f, jump = 7f, groundCheckDist = 0.18f;
    Rigidbody2D rb; float ax;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ax = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") == true && IsGrounded() == true)
        {
            rb.AddForce(new Vector2(0f, jump), ForceMode2D.Impulse);
        }   
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector2(ax * accel, 0f), ForceMode2D.Force);
    }

    bool IsGrounded()
    {
        // �� �߽ɿ��� �ٷ� �Ʒ��� ���� ª�� ���̸� ���� '�ٴ��� �ִ�'�� true
        var hit = Physics2D.Raycast(rb.position, Vector2.down, groundCheckDist);
        return hit.collider != null;
    }
}
