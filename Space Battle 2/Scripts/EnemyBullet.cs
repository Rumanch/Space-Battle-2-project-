using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().TakeDamage();
            Destroy(gameObject);  // Destroy bullet
        }
    }

    void Start()
    {
        Destroy(gameObject, 5f);  // Destroy bullet after 5 seconds if it doesn't hit anything
    }
}



