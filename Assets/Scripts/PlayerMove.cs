using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 실수형 데이터를 저장할 변수.
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
        //  좌우키를 눌렀는지 입력 값을 검사해서 값을 받아온다.
        moveInput = Input.GetAxisRaw("Horizontal");
        // 왼쪽 키를 눌렀을 경우 : -1
        // 오른쪽 키를 눌렀을 경우 : 1
        // 아무 키도 누르지 않았을 경우 : 0

        if(Input.GetButtonDown("Jump") == true && IsGrounded() == true)
        {
            rb.AddForce(new Vector2(0.0f, jumpPower), ForceMode2D.Impulse);
        }
    }

    // 일정한 프레임마다 돌아가면서 물리 관련 처리를 한다.
    // 정확한 물리 처리를 위해 이 안에서 구현을 해주는 것이 좋다.
    private void FixedUpdate()
    {
        // Rigidbody2D에 힘을 가해서 이동시키는 처리.
        // 좌우 이동은 x 방향으로만 힘을 가하면 되기 때문에 x 값만 변경해주고 y값은 그냥 0으로 세팅.
        rb.AddForce(new Vector2(moveInput * movespeed, 0.0f), ForceMode2D.Force);
    }

    bool IsGrounded()
    {
        // 지정한 위치에서 지정한 방향으로 지정된 길이만큼 광선을 쏴서 광선에 충돌하는 오브젝트가 있는지 검사한다.
        var hit = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDist, groundLayer);
        return hit.collider != null;
    }
}
