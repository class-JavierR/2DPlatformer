using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoresButton : MonoBehaviour
{
    public void OnHighScoresClicked()
    {
        SceneManager.LoadScene("HighScores");
    }
}