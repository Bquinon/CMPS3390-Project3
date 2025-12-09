using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenLeaderboard()
    {
        Debug.Log("URL OPENED");
        Application.OpenURL("https://kenyetta-congressional-lyla.ngrok-free.dev/");
    }

    public void QuitGame()
    {
        Debug.Log("GAME QUIT");
        Application.Quit();
    }
}
