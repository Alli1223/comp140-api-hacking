using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System;


public class rainSpawn : MonoBehaviour
{

    public GameObject rain;

    private string APIHTTP = "api.openweathermap.org/data/2.5/weather?q=";
    private string APIKey = "&APPID=d3dcece6b95e45b36bc819afc815e9ef";   //My personal API key that allows for upto 60 calls a min
    private string APIUnits = "&units=metric"; //API unit standard - Metric or Imperial
    private string APIFormat = "&mode=xml";  //return format (default is string text)(&mode=xml for XML)
    private float update_time = 8f; //Update time in seconds
    private string location;

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

    //Returns the IP address of the user
    IEnumerator GETIP()
    {
        string API_IP_URL = "api.ipify.org";
        WWW API_IP = new WWW(API_IP_URL);

        yield return API_IP;
        string IP_Address = API_IP.text;

        //Starts another Coroutine to get the location based on that IP
        StartCoroutine(GetLocation(IP_Address));
        //Debug.Log(IP_Address);
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

    IEnumerator GetWeather(string location)
    {
        //TODO: FIX THIS TO USE THE GENERATED LOCATION#
        if (location.Contains("Falmouth"))
        {
            location = "Falmouth";
        }
        else
        {
            location = "somewhereelse";
        }


        string url = APIHTTP + location + APIKey + APIUnits + APIFormat;
        WWW www = new WWW(url);


        yield return www;

        string API_Content = www.text;
        ReadXML(API_Content);


        //If the weather API request contains the word "Rain" inside then set the rain animation to true
        //TODO: make this more robust by only checking the main weather condition
        /*
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
        */

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


    //Weather condition codes http://openweathermap.org/weather-conditions
    //XML reader copied from https://msdn.microsoft.com/en-us/library/cc189056(v=vs.95).aspx
    private string ReadXML(string XMLString)
    {
        StringBuilder output = new StringBuilder();

        // Create an XmlReader
        using (XmlReader reader = XmlReader.Create(new StringReader(XMLString)))
        {
            int resultvalue;
            reader.ReadToFollowing("weather");
            reader.MoveToFirstAttribute();
            string value = reader.Value;
            output.AppendLine("The Weather value: " + value);
            reader.ReadToFollowing("value");
            Debug.Log(value);

            resultvalue = Convert.ToInt32(value);

             //Drizzle
            if (resultvalue >= 300 && resultvalue <= 321)
            {
                Debug.Log("It's Drizzling");
                rain.SetActive(true);
            }

            //Rain
            else if (resultvalue >= 500 && resultvalue <= 531)
            {
                Debug.Log("It's either raining or drizzleing");
                rain.SetActive(true);
            }        

            //Clear OR Clouds
            else if (resultvalue >= 800 && resultvalue <= 804)
            {
                Debug.Log("It's either clear or cloudy");
                rain.SetActive(false);

            }

            //Extreme

            else if (resultvalue >= 900 && resultvalue <= 906)
            {
                Debug.Log("It's either clear or cloudy");
                rain.SetActive(true);

            }

            output.AppendLine("Content of the Value element: " + reader.ReadElementContentAsString());
            string output_text = output.ToString();
            Debug.Log(output_text);

            return output_text;
        }      
    }




// Update is called once per frame
void Update()
    {

    }
}


