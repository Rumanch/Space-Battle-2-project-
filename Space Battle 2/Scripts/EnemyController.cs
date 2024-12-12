using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab; // Bullet prefab
    public float fireRate = 1f;     // Time interval between shots
    public float moveSpeed = 2f;    // Speed of the enemy

    private float nextFireTime;     // Time tracker for the next shot
    private Transform player;       // Reference to the player
    public EnemySpawner spawner;    // Reference to the spawner (assigned during spawn)

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        MoveTowardsPlayer();
        HandleFiring();
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    void HandleFiring()
    {
        if (Time.time > nextFireTime)
        {
            FireBullet();
            nextFireTime = Time.time + fireRate;
        }
    }

    void FireBullet()
    {
        if (player != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                rb.velocity = direction * 5f; // Adjust speed as needed
            }
        }
    }

    public void DestroyEnemy()
    {
        if (spawner != null)
        {
            spawner.EnemyDestroyed(); // Notify the spawner
        }

        Destroy(gameObject); // Destroy this enemy
    }
}
