using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    void Start()
    {
        UpdateScoreUI(GameManager.Instance.playerScore);
        UpdateHealthUI(GameManager.Instance.playerHealth);
    }
    void OnEnable()
    {
        GameManager.OnScoreChanged += UpdateScoreUI;
        GameManager.OnHealthChanged += UpdateHealthUI;
        GameManager.OnGameOver += HandleGameOver;
    }

    void OnDisable()
    {
        GameManager.OnScoreChanged -= UpdateScoreUI;
        GameManager.OnHealthChanged -= UpdateHealthUI;
        GameManager.OnGameOver -= HandleGameOver;
    }
    void UpdateScoreUI(int newScore)
    {
        Debug.Log("Score Updated: " + newScore);
        scoreText.text = "Score: " + newScore;
    }

    void UpdateHealthUI(int newHealth)
    {
        Debug.Log("Health Updated: " + newHealth);
        healthText.text = "Health: " + newHealth;
    }
    void HandleGameOver()
    {
        SceneManager.LoadScene(3);
    }
}
