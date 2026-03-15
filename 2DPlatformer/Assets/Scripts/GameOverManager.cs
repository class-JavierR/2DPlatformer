using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    
    void Start()
    {
        int finalScore =  GameManager.Instance.playerScore;
        scoreText.text = "Final Score: " + finalScore;
    }
    
    public void Retry()
    {
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
