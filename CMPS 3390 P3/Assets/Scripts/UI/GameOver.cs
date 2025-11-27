using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private float sceneDelay = 10f;
    [SerializeField]
    private string sceneLoad;
    private float timeElasped = 0;

    private void Update()
    {
        timeElasped += Time.deltaTime;
        float timeString = timeElasped;
        Debug.Log("Time Passed: " + timeString.ToString() + "s");
        if (timeElasped >= sceneDelay)
        {
            SceneManager.LoadScene(sceneLoad);
        }
    }
}
