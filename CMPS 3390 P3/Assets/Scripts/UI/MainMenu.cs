using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenLeaderboard()
    {
        Debug.Log("URL OPENED");
        Application.OpenURL("https://cs.csub.edu/~slara/3390/Project3/leaderboard/frontend/");
    }

    public void QuitGame()
    {
        Debug.Log("GAME QUIT");
        Application.Quit();
    }
}
