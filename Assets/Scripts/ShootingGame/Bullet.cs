using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 12f;
    public float lifeTime = 5f;

    private void OnEnable()
    {
        Invoke(nameof(Despawn), lifeTime);
    }

    private void Update()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.CompareTag("Enemy") == true)
        {
            Despawn();
        }
    }

    private void Despawn()
    {
        Destroy(gameObject);
    }
}
