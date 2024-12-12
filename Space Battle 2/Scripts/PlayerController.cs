using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint01;
    public Transform firePoint02;
    public float fireRate = 0.5f;
    private float nextFireTime;

    public float moveSpeed = 5f;
    public int health = 3;
    public GameManager gameManager;

    void Update()
    {
        HandleMovement();
        HandleFiring();
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, vertical, 0) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    void HandleFiring()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFireTime)
        {
            FireBullets();
            nextFireTime = Time.time + fireRate;
        }
    }

    void FireBullets()
    {
        Instantiate(bulletPrefab, firePoint01.position, Quaternion.identity);
        Instantiate(bulletPrefab, firePoint02.position, Quaternion.identity);

        // Play firing sound
        AudioManager.instance.PlayFireSound();
    }

    public void TakeDamage()
    {
        health--;
        gameManager.UpdateHealth(health);

        if (health <= 0)
        {
            gameManager.GameOver();
        }
    }

    public void ResetPlayer()
    {
        health = 3;
        transform.position = new Vector3(0, -4, 0); // Reset position
        gameManager.UpdateHealth(health);
    }
}
