using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadGameScene()
    {
        //clears score
        GameManager.Instance.ResetGame();
        //loads game scene
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        Application.Quit();
        // Note: Quit only works in built games, not in the Unity Editor
    }
}
