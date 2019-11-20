using UnityEngine;
using System.Collections;

public class SwitchCharacters : MonoBehaviour 
{
	GameObject[] playersArray;
	// Use this for initialization
	void Start () 
	{
		playersArray = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CheckForCharacters>().allPlayers;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
			playersArray[0].GetComponent<Movement> ().enabled = true;
			playersArray[1].GetComponent<Movement> ().enabled = false;
		}

		//if (playersArray[1] != null) // YOU MIGHT NEED TO DO THIS FOR EVERY SINGLE CHARACTER THINGY WHATEVER CUZ THIS FIXES THE NULL REFERENCE PROBLEM WE BEEN HAVIN

		 if (Input.GetKeyDown (KeyCode.Alpha2)) 
		{
			playersArray[1].GetComponent<Movement>().enabled = true;
			playersArray[0].GetComponent<Movement>().enabled = false;
		}
		SwitchCodes();
	}
	void SwitchCodes ()
	{
		foreach (GameObject player in playersArray)
		{
			if(player.GetComponent<Movement>().enabled == true)
			{
				player.GetComponent<FollowCode>().enabled = false;
			}
			else if(player.GetComponent<Movement>().enabled == false)
			{
				if(player.GetComponent<Hiding>() != null)
				{
					if(player.GetComponent<Hiding>().isHiding == false)
					{
						player.GetComponent<FollowCode>().enabled = true;
					}
				}
			}
		}
	}
}