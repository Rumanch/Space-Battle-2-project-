using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 10f; // Bullet speed

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed; // Bullet travels upward
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyController enemy = collision.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.DestroyEnemy(); // Destroy the enemy
                FindObjectOfType<GameManager>().IncrementScore(); // Increment score
            }
            Destroy(gameObject); // Destroy the bullet
        }
    }
}


