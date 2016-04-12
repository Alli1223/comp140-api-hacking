using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class rainSpawn : MonoBehaviour
{

	public GameObject rain;
	private int minTime = 1;
	private int maxTime = 4;

	private int rainSpawner;

    public string location;

    private string APIText ;
    public string APIurl;
    public string APIHTTP = "http://api.openweathermap.org/data/2.5/weather?q=";
    public string APIKey = "&APPID=d3dcece6b95e45b36bc819afc815e9ef";
    public string APIFormat = "&mode=xml";



    // Use this for initialization
    void Start ()
	{
        location = "Falmouth";

        //Request XML
        string APIurl = APIHTTP + location + APIKey + APIFormat;
 
        WWW www = new WWW(APIurl);
        APIText = www.text;

        //Write XML


        //readXML


        /* Previous random version

    rainSpawner = Random.Range(minTime,maxTime);
		if (rainSpawner <= 2)
		{
			rain.SetActive(true);
		}
		if (rainSpawner > 2)
		{
			rain.SetActive(false);
		}

    */

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
