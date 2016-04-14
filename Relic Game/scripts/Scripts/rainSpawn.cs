using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.IO;


public class rainSpawn : MonoBehaviour
{

	public GameObject rain;

    public string APIurl;

    public string APIHTTP = "api.openweathermap.org/data/2.5/weather?q=";
    public string location = "Falmouth";
    public string APIKey = "&APPID=d3dcece6b95e45b36bc819afc815e9ef";   //My personal API key that allows for upto 600 calls an hour
    public string APIUnits = "&units=metric"; //API unit standard - Metric or Imperial
    public string APIFormat = "";  //return format (default is string text)
    bool isWaiting;

    // Use this for initialization
    void Start()
    {

            string url = APIHTTP + location + APIKey + APIUnits;
            WWW www = new WWW(url);
            //StartCoroutine(GetWeather(www));
            StartCoroutine(UpdateWeather(10.0f, www));
    }


    IEnumerator GetWeather(WWW www)
    {

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

    IEnumerator UpdateWeather(float waitTime, WWW www)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            StartCoroutine(GetWeather(www));
        }
    }






        // Update is called once per frame
        void Update ()
	{
	
	}


}


