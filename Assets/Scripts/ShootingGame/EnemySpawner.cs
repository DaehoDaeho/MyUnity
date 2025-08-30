using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public float spawnInterval = 1.2f;

    private float nextTime = 0f;

    private void Update()
    {
        if (Time.time >= nextTime)
        {
            SpawnOne();
            nextTime = Time.time + spawnInterval;
        }
    }

    private void SpawnOne()
    {
        if (enemyPrefab != null && Camera.main != null)
        {
            Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 0f));
            Vector3 max = Camera.main.ViewportToWorldPoint(new Vector3(1f, 1f, 0f));

            float x = Random.Range(min.x + 0.5f, max.x - 0.5f);
            float y = max.y + 1f;

            int index = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[index], new Vector3(x, y, 0f), Quaternion.identity);
        }
    }
}
