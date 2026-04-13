using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float spawnWidth = 5f; // Зона спавну по осі X

    private ObjectPool enemyPool;
    private float timer;

    private void Awake()
    {
        enemyPool = GetComponent<ObjectPool>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnEnemy();
            timer = spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemy = enemyPool.GetObject();

        // Рандомізація позиції по X
        float randomX = Random.Range(-spawnWidth, spawnWidth);
        enemy.transform.position = new Vector2(transform.position.x + randomX, transform.position.y);
    }

    // Для візуалізації зони спавну в редакторі
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(transform.position.x - spawnWidth, transform.position.y, 0),
                        new Vector3(transform.position.x + spawnWidth, transform.position.y, 0));
    }
}