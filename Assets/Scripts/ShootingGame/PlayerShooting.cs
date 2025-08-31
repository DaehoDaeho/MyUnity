using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject[] bulletPrefab;
    public Transform muzzle;
    public float fireRate = 6f; // 초당 발사 수

    private float nextFireTime = 0f;
    private int bulletIndex = 0;

    private void Update()
    {
        if ((Input.GetButton("Fire1") == true || Input.GetKey(KeyCode.Space) == true) && Time.time >= nextFireTime)
        {
            if (bulletPrefab != null && muzzle != null)
            {
                Instantiate(bulletPrefab[bulletIndex], muzzle.position, Quaternion.identity);
            }

            nextFireTime = Time.time + (1f / fireRate);
        }

        if(Input.GetKeyDown(KeyCode.Alpha1) == true)
        {
            bulletIndex = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) == true)
        {
            bulletIndex = 1;
        }
    }
}
