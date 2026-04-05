using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverManager : MonoBehaviour
{
    
    public TMP_InputField playerNameInput;
    public TextMeshProUGUI scoreText;

    int finalScore;
    float completionTime;
    
    void Start()
    {
        finalScore = GameManager.Instance.GetScore();
        completionTime = GameManager.Instance.GetCompletionTime();
        scoreText.text = "Final Score: " + finalScore;
    }
    string GetPlayerName()
    {
        string playerName = playerNameInput.text.Trim();

        if (string.IsNullOrEmpty(playerName))
        {
            playerName = "Anonymous";
        }

        return playerName;
    }
    void SaveScore()
    {
        string playerName = GetPlayerName();
        DatabaseManager.Instance.SaveHighScore(playerName, finalScore, completionTime);
    }

    public void OnSubmitScore()
    {
        SaveScore();
        SceneManager.LoadScene("HighScores");
    }    
    public void Retry()
    {
        SaveScore();
        //loads game scene to retry
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene(2);
    }
    
    public void ReturnToMenu()
    {
        //returns to main menu
        GameManager.Instance.ResetGame();
        SceneManager.LoadScene(1);
    }
}
