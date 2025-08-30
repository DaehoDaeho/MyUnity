using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2.5f;
    public int hp = 1;
    public int scoreOnKill = 100;

    private void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (Camera.main != null)
        {
            Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));

            if (transform.position.y < min.y - 1f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.CompareTag("PlayerBullet") == true)
        {
            hp = hp - 1;

            if (hp <= 0)
            {
                GameManager gm = FindAnyObjectByType<GameManager>();

                if (gm != null)
                {
                    gm.AddScore(scoreOnKill);
                }

                Destroy(gameObject);
            }
        }
    }
}
