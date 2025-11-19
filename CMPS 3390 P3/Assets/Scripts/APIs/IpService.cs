using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace WeatherApp.API
{
    [Serializable]
    public class IpifyResponse
    {
        public string ip;
    }

    public class IpService : MonoBehaviour
    {
        public IEnumerator GetPublicIp(Action<string> onSuccess, Action<string> onError)
        {
            using (UnityWebRequest request = UnityWebRequest.Get("https://api.ipify.org?format=json"))
            {
                yield return request.SendWebRequest();

#if UNITY_2020_1_OR_NEWER
                if (request.result != UnityWebRequest.Result.Success)
#else
                if (request.isHttpError || request.isNetworkError)
#endif
                {
                    onError?.Invoke(request.error);
                }
                else
                {
                    try
                    {
                        var ipResponse = JsonUtility.FromJson<IpifyResponse>(request.downloadHandler.text);
                        onSuccess?.Invoke(ipResponse.ip);
                    }
                    catch (Exception exception)
                    {
                        onError?.Invoke(exception.Message);
                    }
                }
            }
        }
    }
}
