using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    public AudioSource musicSource;
    public AudioSource sfxSource;
    
    public AudioClip backgroundMusic;
    public AudioClip coinSound;
    public AudioClip jumpSound;
    public AudioClip damageSound;
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        PlayMusic(backgroundMusic);
    }
    
    private void OnEnable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.OnScoreChanged += HandleScoreChanged;
            GameManager.OnHealthChanged += HandleHealthChanged;
        }
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
        {
            GameManager.OnScoreChanged -= HandleScoreChanged;
            GameManager.OnHealthChanged -= HandleHealthChanged;
        }
    }

    private void HandleScoreChanged(int newScore)
    {
        PlaySoundEffect(coinSound);
        Debug.Log("Coin sound played via event");
    }

    private void HandleHealthChanged(int newHealth)
    {
        PlaySoundEffect(damageSound);
        Debug.Log("Damage sound played via event");
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip != null && musicSource.clip != clip)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }
    }
}