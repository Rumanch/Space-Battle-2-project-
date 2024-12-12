using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text scoreText;           // Score HUD text
    public Text gameOverScoreText;   // Total Score on Game Over
    public Slider healthSlider;      // Health bar slider
    public GameObject gameOverPanel; // Game Over panel
    public PlayerController player;  // Reference to PlayerController
    public EnemySpawner spawner;     // Reference to EnemySpawner

    private int score = 0;           // Player's score

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        gameOverPanel.SetActive(false);
        UpdateScoreText();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = "Total Score: " + score; // Show final score
        Time.timeScale = 0; // Pause the game

        // Play game over sound and lower background music
        AudioManager.instance.PlayGameOverSound();
        AudioManager.instance.LowerBackgroundMusic();
    }

    public void IncrementScore()
    {
        score++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateHealth(int currentHealth)
    {
        healthSlider.value = currentHealth;
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Resume the game
        score = 0;
        UpdateScoreText();
        healthSlider.value = healthSlider.maxValue;
        gameOverPanel.SetActive(false);

        // Reset player
        if (player != null)
        {
            player.ResetPlayer();
        }

        // Reset enemies
        if (spawner != null)
        {
            spawner.ResetSpawner();
        }

        // Reset audio
        AudioManager.instance.ResetBackgroundMusicVolume();

        // Clear bullets
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("EnemyBullet");
        foreach (GameObject bullet in bullets)
        {
            Destroy(bullet);
        }
    }
}
