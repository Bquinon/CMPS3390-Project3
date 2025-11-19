using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace WeatherApp.API
{
    [Serializable]
    public class GeoLocation
    {
        public float latitude;
        public float longitude;
    }

    [Serializable]
    public class GeoResponse
    {
        public GeoLocation location;
    }

    public class GeoService : MonoBehaviour
    {
        public string apiKey;

        public IEnumerator GetGeoForIp(string ipAddress, Action<float, float> onSuccess, Action<string> onError)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                onError?.Invoke("Geo API key not set.");
                yield break;
            }

            string url = $"https://geo.ipify.org/api/v2/country,city?apiKey={apiKey}&ipAddress={ipAddress}";

            using (UnityWebRequest request = UnityWebRequest.Get(url))
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
                        var geoResponse = JsonUtility.FromJson<GeoResponse>(request.downloadHandler.text);
                        onSuccess?.Invoke(geoResponse.location.latitude, geoResponse.location.longitude);
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
