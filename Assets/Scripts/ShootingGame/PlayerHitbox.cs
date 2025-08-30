using UnityEngine;

public class PlayerHitbox : MonoBehaviour
{
    public int damageOnHit = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.CompareTag("Enemy") == true)
        {
            GameManager gm = FindAnyObjectByType<GameManager>();

            if (gm != null)
            {
                gm.DamagePlayer(damageOnHit);
            }
        }
    }
}
