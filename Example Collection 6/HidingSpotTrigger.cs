using UnityEngine;
using System.Collections;

public class HidingSpotTrigger : MonoBehaviour 
{
	public bool nearHidingSpot;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnTriggerEnter2D (Collider2D Other)
	{
		if(Other.tag == "Player")
		{
			nearHidingSpot = true;
		}
	}

	void OnTriggerExit2D (Collider2D Other)
	{
		if (Other.tag == "Player")
		{
			nearHidingSpot = false;
		}
	}
}