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

    public string APIHTTP = "http://api.openweathermap.org/data/2.5/weather?q=";
    public string location = "Falmouth";
    public string APIKey = "&APPID=d3dcece6b95e45b36bc819afc815e9ef";   //My personal API key that allows for upto 600 calls an hour
    public string APIUnits = "&units=metric"; //API unit standard - Metric or Imperial
    public string APIFormat = "";  //XML format &mode=xml


    // Use this for initialization
    void Start ()
	{
        
        //Create XML document
        XmlDocument xmlDoc = new XmlDocument();


        //Concatinated XML Request
        string APIurl = APIHTTP + location + APIKey + APIUnits + APIFormat;
        Debug.Log(APIurl);

        string API_Content = getAPIContent(APIurl);


        string raintext = API_Content.Substring(0, API_Content.IndexOf("RAIN"));

        Debug.Log(API_Content);
        if (raintext.Contains("RAIN"))
        {
            rain.SetActive(true);
        }
        else
            rain.SetActive(false);


        //write xml function
        //WriteXML(API_Content);


        //readXML
    }


    public string getAPIContent(string APIurl)
    {
        WWW www = new WWW(APIurl);
        string APIcontent = www.text;
        
        return APIcontent;
    }

    /*Write XML
    public void WriteXML(string API_Content)
    {
        Debug.Log(API_Content);
        string raintext = API_Content.Substring(0, API_Content.IndexOf("RAIN"));

        if(raintext.Contains("RAIN"))
        {
            rain.SetActive(true);
        }
        else
            rain.SetActive(false);
    }
    */



    // Update is called once per frame
    void Update ()
	{
	
	}


}


