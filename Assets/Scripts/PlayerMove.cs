using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �Ǽ��� �����͸� ������ ����.
    public float movespeed = 30.0f;

    public float jumpPower = 10.0f;
    public float groundCheckDist = 0.18f;

    public Rigidbody2D rb;
    private float moveInput;
    public Transform groundCheck;
    public LayerMask groundLayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //  �¿�Ű�� �������� �Է� ���� �˻��ؼ� ���� �޾ƿ´�.
        moveInput = Input.GetAxisRaw("Horizontal");
        // ���� Ű�� ������ ��� : -1
        // ������ Ű�� ������ ��� : 1
        // �ƹ� Ű�� ������ �ʾ��� ��� : 0

        if(Input.GetButtonDown("Jump") == true && IsGrounded() == true)
        {
            rb.AddForce(new Vector2(0.0f, jumpPower), ForceMode2D.Impulse);
        }
    }

    // ������ �����Ӹ��� ���ư��鼭 ���� ���� ó���� �Ѵ�.
    // ��Ȯ�� ���� ó���� ���� �� �ȿ��� ������ ���ִ� ���� ����.
    private void FixedUpdate()
    {
        // Rigidbody2D�� ���� ���ؼ� �̵���Ű�� ó��.
        // �¿� �̵��� x �������θ� ���� ���ϸ� �Ǳ� ������ x ���� �������ְ� y���� �׳� 0���� ����.
        rb.AddForce(new Vector2(moveInput * movespeed, 0.0f), ForceMode2D.Force);
    }

    bool IsGrounded()
    {
        // ������ ��ġ���� ������ �������� ������ ���̸�ŭ ������ ���� ������ �浹�ϴ� ������Ʈ�� �ִ��� �˻��Ѵ�.
        var hit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDist, groundLayer);
        return hit.collider != null;
    }
}
