using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Enemy prefab to spawn
    public Vector3 spawnAreaMin;   // Minimum bounds for spawning
    public Vector3 spawnAreaMax;   // Maximum bounds for spawning

    private GameObject currentEnemy; // Reference to the currently active enemy

    public void Start()
    {
        SpawnEnemy(); // Spawn the initial enemy
    }

    public void SpawnEnemy()
    {
        if (currentEnemy == null) // Ensure only one enemy exists
        {
            float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
            float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

            currentEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            currentEnemy.GetComponent<EnemyController>().spawner = this; // Assign the spawner to the enemy
        }
    }

    public void EnemyDestroyed()
    {
        currentEnemy = null; // Clear the reference to the destroyed enemy
        SpawnEnemy();        // Spawn the next enemy
    }

    public void ResetSpawner()
    {
        // Clear the existing enemy, if any
        if (currentEnemy != null)
        {
            Destroy(currentEnemy);
            currentEnemy = null;
        }

        SpawnEnemy(); // Spawn the initial enemy
    }
}
