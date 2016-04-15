﻿using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.IO;


public class rainSpawn : MonoBehaviour
{

    public GameObject rain;


    private string APIHTTP = "api.openweathermap.org/data/2.5/weather?q=";
    private string APIKey = "&APPID=d3dcece6b95e45b36bc819afc815e9ef";   //My personal API key that allows for upto 600 calls an hour
    private string APIUnits = "&units=metric"; //API unit standard - Metric or Imperial
    private string APIFormat = "";  //return format (default is string text)
    private float update_time = 10f; //Update time in seconds
    public string location = "Bath";

    // Use this for initialization
    void Start()
    {

        StartCoroutine(UpdateWeather(update_time));

    }


    //Constantly calls the function GetWeather then waits a set amnmount of time
    IEnumerator UpdateWeather(float update_time)
    {
        while (true)
        {
            StartCoroutine(GETIP());
            yield return new WaitForSeconds(update_time);
        }
    }

    //If the weather API request contains the word "Rain" inside then set the rain animation to true, else don't
    IEnumerator GetWeather(string location)
    {
        //TODO: FIX THIS TO USE THE GENERATED LOCATION
        
        location = "Bath";
        //Weird unity issue?

        string url = APIHTTP + location + APIKey + APIUnits;
        Debug.Log(location);
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

    
    //Returns the IP address of the user
    IEnumerator GETIP()
    {
        string API_IP_URL = "api.ipify.org";
        WWW API_IP = new WWW(API_IP_URL);
        
        yield return API_IP;
        string IP_Address = API_IP.text;

        //Starts another Coroutine to get the location based on that IP
        StartCoroutine(GetLocation(IP_Address));
        Debug.Log(IP_Address);
    }

    IEnumerator GetLocation(string IP_Address)
    {
        string IP_Location_URL_start = "http://ipinfo.io/"; //1000 Daily requests allowed for free
        string IP_Location_URL_end = "/city";
        string IP_Location_URL = IP_Location_URL_start + IP_Address + IP_Location_URL_end;
        WWW IP_Location = new WWW(IP_Location_URL);
        yield return IP_Location;

        string location = IP_Location.text;

        StartCoroutine(GetWeather(location));
    }

    // Update is called once per frame
    void Update()
    {

    }


}


