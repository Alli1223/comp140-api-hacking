using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.IO;


public class rainSpawn : MonoBehaviour
{

    public GameObject rain;
    private int minTime = 1;
    private int maxTime = 4;

    private int rainSpawner;



    public string APIurl;

    public string APIHTTP = "api.openweathermap.org/data/2.5/weather?q=";
    public string location = "Falmouth";
    public string APIKey = "&APPID=d3dcece6b95e45b36bc819afc815e9ef";   //My personal API key that allows for upto 600 calls an hour
    public string APIUnits = "&units=metric"; //API unit standard - Metric or Imperial
    public string APIFormat = "api.openweathermap.org/data/2.5/weather?q=";  //XML format &mode=xml


    // Use this for initialization
    void Start()
    {

        string url = "http://api.openweathermap.org/data/2.5/weather?q=Falmouth&APPID=d3dcece6b95e45b36bc819afc815e9ef&units=metric";
        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));

    }


    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        string API_Content = www.data;

        if (API_Content.Contains("RAIN"))
        {
            rain.SetActive(true);
        }
        else
        {
            rain.SetActive(false);
        }


        // check for errors
        if (www.error == null)
        {
            Debug.Log("Request Recieved!: " + www.data);
        }
        else {
            Debug.Log("WWW Error: " + www.error);
        }
    }




    // Update is called once per frame
    void Update()
    {

    }


}


