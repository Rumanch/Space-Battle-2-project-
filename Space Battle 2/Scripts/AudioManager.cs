using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip backgroundMusic;  // Background music clip
    public AudioClip gameOverSound;    // Game over sound clip
    public AudioClip fireSound;        // Fire sound clip

    private AudioSource audioSource;   // Single audio source for playing sounds

    void Awake()
    {
        // Singleton pattern to ensure only one AudioManager exists
        if (instance == null) instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject); // Persist through scenes
    }

    void Start()
    {
        // Attach AudioSource component and configure it
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true; // Loop the background music
        PlayBackgroundMusic();
    }

    // Play background music
    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.volume = 1.0f;
            audioSource.Play();
        }
    }

    // Play fire sound
    public void PlayFireSound()
    {
        if (fireSound != null)
        {
            audioSource.PlayOneShot(fireSound);
        }
    }

    // Play game over sound
    public void PlayGameOverSound()
    {
        if (gameOverSound != null)
        {
            audioSource.PlayOneShot(gameOverSound);
        }
    }

    // Lower background music volume (e.g., during game over)
    public void LowerBackgroundMusic()
    {
        audioSource.volume = 0.3f; // Set to a lower volume
    }

    // Reset background music volume to normal
    public void ResetBackgroundMusicVolume()
    {
        audioSource.volume = 1.0f; // Reset to full volume
    }
}
