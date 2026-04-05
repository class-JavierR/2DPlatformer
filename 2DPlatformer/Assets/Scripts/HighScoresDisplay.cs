using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class HighScoresDisplay : MonoBehaviour
{
    public TextMeshProUGUI[] scoreTexts;
    
    void Start()
    {
        DisplayHighScores();
    }
    
    void DisplayHighScores()
    {
    List<HighScore> topScores = DatabaseManager.Instance.GetTopHighScores(5);
    
    if (topScores.Count == 0)
    {
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            scoreTexts[i].text = (i + 1) + ". No scores yet!";
        }
        return;
    }
        for (int i = 0; i < scoreTexts.Length; i++)
        {
            if (i < topScores.Count)
            {
                HighScore score = topScores[i];
                int rank = i + 1;
                scoreTexts[i].text = rank + ". " + score.PlayerName + " - " + 
                                    score.Score + " pts - " + 
                                    score.CompletionTime.ToString("F1") + "s";
            }
            else
            {
                scoreTexts[i].text = (i + 1) + ". ---";
            }
        }
    }
}