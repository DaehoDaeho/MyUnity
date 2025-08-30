using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzle;
    public float fireRate = 6f; // 초당 발사 수

    private float nextFireTime = 0f;

    private void Update()
    {
        if ((Input.GetButton("Fire1") == true || Input.GetKey(KeyCode.Space) == true) && Time.time >= nextFireTime)
        {
            if (bulletPrefab != null && muzzle != null)
            {
                Instantiate(bulletPrefab, muzzle.position, Quaternion.identity);
            }

            nextFireTime = Time.time + (1f / fireRate);
        }
    }
}
