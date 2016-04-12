using UnityEngine;
using System.Collections;

public class rainSpawn : MonoBehaviour
{

	public GameObject rain;
	private int minTime = 1;
	private int maxTime = 4;

	private int rainSpawner;


	// Use this for initialization
	void Start ()
	{
//		rain = GetComponentsInChildren<gameObject>();
		rainSpawner = Random.Range(minTime,maxTime);
		if (rainSpawner <= 2)
		{
			rain.SetActive(true);
		}
		if (rainSpawner > 2)
		{
			rain.SetActive(false);
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
