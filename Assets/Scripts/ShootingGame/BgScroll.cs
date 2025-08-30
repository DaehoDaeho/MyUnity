using UnityEngine;

public class BgScroll : MonoBehaviour
{
    public Transform bg1;
    public Transform bg2;
    public float speed = 2f;

    private float height;

    private void Start()
    {
        if (bg1 != null && bg2 != null)
        {
            height = Mathf.Abs(bg2.position.y - bg1.position.y);
        }
    }

    private void Update()
    {
        if (bg1 != null)
        {
            bg1.position += Vector3.down * speed * Time.deltaTime;
        }

        if (bg2 != null)
        {
            bg2.position += Vector3.down * speed * Time.deltaTime;
        }

        if (bg1 != null && bg1.position.y <= -height)
        {
            bg1.position = new Vector3(bg1.position.x, bg1.position.y + (height * 2f), bg1.position.z);
        }

        if (bg2 != null && bg2.position.y <= -height)
        {
            bg2.position = new Vector3(bg2.position.x, bg2.position.y + (height * 2f), bg2.position.z);
        }
    }
}
