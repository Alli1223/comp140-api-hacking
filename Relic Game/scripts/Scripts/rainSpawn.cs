using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.IO;


public class rainSpawn : MonoBehaviour
{

    public GameObject rain;


    private string APIHTTP = "api.openweathermap.org/data/2.5/weather?q=";
    public string location = "";
    private string APIKey = "&APPID=d3dcece6b95e45b36bc819afc815e9ef";   //My personal API key that allows for upto 600 calls an hour
    private string APIUnits = "&units=metric"; //API unit standard - Metric or Imperial
    private string APIFormat = "";  //return format (default is string text)
    private float update_time = 10f; //Update time in seconds


    // Use this for initialization
    void Start()
    {
        string API_IP_URL = "api.ipify.org";
        WWW API_IP = new WWW(API_IP_URL);

        //string url = APIHTTP + location + APIKey + APIUnits;
        //WWW www = new WWW(url);


        StartCoroutine(UpdateWeather(update_time, API_IP));
    }

    //If the weather API request contains the word "Rain" inside then set the rain animation to true, else don't

    IEnumerator GetWeather()
    {
        string url = APIHTTP + location + APIKey + APIUnits;
        WWW www = new WWW(url);

        yield return www;

        string API_Content = www.text;

        if (API_Content.Contains("Rain"))
        {
            rain.SetActive(true);
            Debug.Log("It is Raining");
        }
        else
        {
            rain.SetActive(false);
            Debug.Log("It is not Raining");
        }

        // check for errors
        if (www.error == null)
        {
            Debug.Log("Weather Request Recieved!: " + www.text);
        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }

    }

    //Constantly calls the function GetWeather then waits a set amnmount of time
    IEnumerator UpdateWeather(float update_time, WWW API_URL)
    {
        while (true)
        {
            StartCoroutine(GETIP(API_URL));
            StartCoroutine(GetWeather());

            yield return new WaitForSeconds(update_time);
        }
    }


    //Returns the IP address of the user
    IEnumerator GETIP(WWW API_URL)
    {
        yield return API_URL;
        string IP_Address = API_URL.text;

        //Starts another Coroutine to get the location based on that IP
        StartCoroutine(GetLocation(IP_Address));
        Debug.Log(IP_Address);
    }

    IEnumerator GetLocation(string IP_Address)
    {
        string IP_Location_URL_start = "http://ipinfo.io/";
        string IP_Location_URL_end = "/city";
        string IP_Location_URL = IP_Location_URL_start + IP_Address + IP_Location_URL_end;
        WWW IP_Location = new WWW(IP_Location_URL);
        Debug.Log(location);
        yield return IP_Location;
        
        
    }

    // Update is called once per frame
    void Update()
    {

    }


}


