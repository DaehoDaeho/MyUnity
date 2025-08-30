using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerShip : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float screenMargin = 0.2f;

    private Camera cam;
    private Vector2 minWorld;
    private Vector2 maxWorld;

    private void Start()
    {
        cam = Camera.main;

        if (cam != null)
        {
            Vector3 min = cam.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
            Vector3 max = cam.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));
            minWorld = new Vector2(min.x + screenMargin, min.y + screenMargin);
            maxWorld = new Vector2(max.x - screenMargin, max.y - screenMargin);
        }
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(x, y, 0f).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;

        Vector3 p = transform.position;

        if (p.x < minWorld.x)
        {
            p.x = minWorld.x;
        }

        if (p.x > maxWorld.x)
        {
            p.x = maxWorld.x;
        }

        if (p.y < minWorld.y)
        {
            p.y = minWorld.y;
        }

        if (p.y > maxWorld.y)
        {
            p.y = maxWorld.y;
        }

        transform.position = p;
    }
}
