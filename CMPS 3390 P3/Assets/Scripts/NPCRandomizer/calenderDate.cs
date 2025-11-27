using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TMPro.Examples;

public class calenderDate : MonoBehaviour
{
    public string[] monthList;
    public string month;
    public int year;
    public string date;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // random month
        monthList = new string[] {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
        int randMonthInd = Random.Range(0, monthList.Length);
        month = monthList[randMonthInd];

        // random year
        year = 2000 + Random.Range(-10, 20);
        string yearString = year.ToString();

        // combine month and year
        date = month + '/' + yearString;

        // set text mesh to date
        TextMeshPro text = GetComponent<TextMeshPro>();
        text.text = date;
    }
}
