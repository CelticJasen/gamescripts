using UnityEngine;
using System.Collections;


public class Hiding : MonoBehaviour 
{
	SpriteRenderer visibility;
//	Transform pTransform;
//	GameObject walking;
	GameObject hiding;
	public bool isHiding = false;
	GameObject[] allPlayers;



	// Use this for initialization
	void Start () 
	{
		visibility = GetComponent<SpriteRenderer>();
//		pTransform = GetComponent<Transform>();
		hiding = GameObject.FindGameObjectWithTag("HidingSpot");
//		walking = GameObject.FindGameObjectWithTag("Player");
		allPlayers = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CheckForCharacters>().allPlayers;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isHiding)
		{
			foreach(GameObject player in allPlayers)
			{
				visibility.enabled = false;
				transform.position = new Vector2 (0.875f, -5.541f);
				player.GetComponent<FollowCode>().enabled = false;

				if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W)|| Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightArrow))
				{
					visibility.enabled = false;
					transform.position = new Vector2 (0.875f, -5.541f);
				}
			}
		}
		if(!isHiding)
		{
			visibility.enabled = true;
		}
		if(hiding.GetComponent<HidingSpotTrigger>().nearHidingSpot == true)
		{
			if(Input.GetKeyDown(KeyCode.Space))
			{
				isHiding = true;
			}
		
			if((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && isHiding == true)
			{
				transform.position = new Vector2 (0.728f, -5.541f);
				isHiding = false;
				Debug.Log ("I pressed Left");
			}

			if((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && isHiding == true)
			{
				transform.position = new Vector2 (0.85f, -5.812f);
				isHiding = false;
			}

			

		}
	}
}

