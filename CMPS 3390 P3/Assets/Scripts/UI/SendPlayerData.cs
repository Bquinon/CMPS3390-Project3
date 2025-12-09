using System.Collections;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SendPlayerData : MonoBehaviour
{
    public GameObject inputField;
    public GameObject warningLabel;
    public TextMeshProUGUI resultField;
    public new string name;
    public string resultText;

    public void Start()
    {
        warningLabel.SetActive(false); // Hide Warning
    }

    public void ReadInput()
    {
        name = inputField.GetComponent<TMP_InputField>().text;
    }

    public bool ValidateInput()
    {
        // var to check if validated
        bool returnResult = true;

        // input is empty
        if(string.IsNullOrWhiteSpace(name))
        {
            resultText = "You did not enter a name";
            returnResult = false;
        }

        // input has non-letter characters
        else if(!name.All(char.IsLetter))
        {
            resultText = "Your name contains non-letter characters";
            returnResult = false;
        }

        // input too short
        else if(name.Length < 3)
        {
            resultText = "The name you entered is too short.";
            returnResult = false;
        }

        // input too long
        else if(name.Length > 15)
        {
            resultText = "The name you entered is too long.";
            returnResult = false;
        }

        resultField.text = resultText;
        warningLabel.SetActive(true); // Display Warning
        return returnResult;
    }

    public IEnumerator SendJsonToServer(string json)
    {
        string url = "https://cs.csub.edu/~slara/3390/Project3/backend/addScore.php";

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("JSON Sent Successfully: " + request.downloadHandler.text);
        }
        else
        {
            Debug.LogError("Error sending JSON: " + request.error);
        }

    }


    public void createJson()
    {
        ReadInput();

        // user input wasn't validated
        if (ValidateInput() == false) { return; }

        else
        {
            // create PlayerData instance
            PlayerData data = new PlayerData();

            // set data
            data.score = compareNPCdata.score;
            data.seconds = compareNPCdata.seconds;
            data.name = name;

            // save as JSON
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(Application.dataPath + "/playerData.json", json);

            StartCoroutine(SendJsonToServer(json));

            SceneManager.LoadScene("MainMenu");

        }
    }
}
