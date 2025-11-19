using System;
using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;

namespace WeatherApp.API
{
    [Serializable]
    public class Hourly
    {
        public string[] time;
        public int[] is_day;
        public float[] rain;
        public float[] showers;
        public int[] weathercode;
    }

    [Serializable]
    public class OpenMeteoResponse
    {
        public Hourly hourly;
    }

    public class WeatherService : MonoBehaviour
    {
        public IEnumerator GetHourlyWeather(double latitude, double longitude, Action<OpenMeteoResponse> onSuccess, Action<string> onError)
        {
            string url =
                $"https://api.open-meteo.com/v1/forecast?" +
                $"latitude={latitude.ToString(CultureInfo.InvariantCulture)}" +
                $"&longitude={longitude.ToString(CultureInfo.InvariantCulture)}" +
                $"&hourly=is_day,rain,showers,weathercode" +
                $"&timezone=auto";

            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                yield return request.SendWebRequest();

#if UNITY_2020_1_OR_NEWER
                if (request.result != UnityWebRequest.Result.Success)
#else
                if (request.isNetworkError || request.isHttpError)
#endif
                {
                    onError?.Invoke(request.error);
                }
                else
                {
                    try
                    {
                        var weatherResponse = JsonUtility.FromJson<OpenMeteoResponse>(request.downloadHandler.text);
                        onSuccess?.Invoke(weatherResponse);
                    }
                    catch (Exception exception)
                    {
                        onError?.Invoke(exception.Message);
                    }
                }
            }
        }

        public static int FindNearestIndex(string[] times)
        {
            if (times == null || times.Length == 0) return -1;

            DateTime now = DateTime.Now;
            double smallestTimeDifference = double.MaxValue;
            int closestTimeIndex = 0;

            for (int i = 0; i < times.Length; i++)
            {
                if (DateTime.TryParse(times[i], out DateTime parsedTime))
                {
                    double timeDifference = Math.Abs((parsedTime - now).TotalMinutes);
                    if (timeDifference < smallestTimeDifference)
                    {
                        smallestTimeDifference = timeDifference;
                        closestTimeIndex = i;
                    }
                }
            }

            return closestTimeIndex;
        }
    }
}
