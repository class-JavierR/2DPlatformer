using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int playerHealth = 100;
    public int playerScore = 0;

    // Delegates
    public delegate void ScoreChanged(int newScore);
    public delegate void HealthChanged(int newHealth);
    public delegate void GameOver();

    // Events
    public static event ScoreChanged OnScoreChanged;
    public static event HealthChanged OnHealthChanged;
    public static event GameOver OnGameOver;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        playerScore += amount;
        OnScoreChanged?.Invoke(playerScore);
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        if (playerHealth < 0) playerHealth = 0; {
        OnHealthChanged?.Invoke(playerHealth); }

        if (playerHealth <= 0) { 
            TriggerGameOver(); }
    }
    public void TriggerGameOver()
    {
        OnGameOver?.Invoke();
    }
    public void ResetGame()
    {
        playerHealth = 100;
        playerScore = 0;
        OnScoreChanged?.Invoke(playerScore);
        OnHealthChanged?.Invoke(playerHealth);
    }
}
