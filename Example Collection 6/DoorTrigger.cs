using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour
{

//	private GameObject player;

	public bool doorTrigger;
	
	// Use this for initialization
	void Start () 
	{
//		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	void OnTriggerStay2D (Collider2D Other)
	{
		if (Other.tag == "Player")
		{
			doorTrigger = true;
		}
		else
		{
			doorTrigger = false;
		}
	}
}