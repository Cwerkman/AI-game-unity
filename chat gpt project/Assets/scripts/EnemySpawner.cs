using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float spawnRadius = 20f;
    public float spawnInterval = 2f;
    private float timer;

    void Start()
    {
        
    }
    private void Update()
    {
        timer += Time.deltaTime;

        float difficulty =
            GameManager.Instance.GetDifficultyMultiplier();

        float currentSpawnInterval =
            Mathf.Max(0.3f, 2f / difficulty);

        if (timer >= currentSpawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        Vector2 randomCircle =
            Random.insideUnitCircle.normalized * spawnRadius;

        Vector3 spawnPosition = new Vector3(
            randomCircle.x,
            50f,   // spawn high in the air
            randomCircle.y
        );

        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Get collider size
        Collider col = enemy.GetComponent<Collider>();

        if (col != null)
        {
            RaycastHit hit;

            // Raycast down to ground
            if (Physics.Raycast(spawnPosition, Vector3.down, out hit, 100f))
            {
                float heightOffset = col.bounds.extents.y;

                enemy.transform.position = hit.point + Vector3.up * heightOffset;
            }
        }
    }
}
