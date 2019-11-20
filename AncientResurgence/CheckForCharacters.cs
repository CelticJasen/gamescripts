using UnityEngine;
using System.Collections;

public class CheckForCharacters : MonoBehaviour 
{

	[SerializeField]private GameObject[] getAllPlayers;
	public GameObject[] allPlayers = new GameObject[5];

	// Use this for initialization
	void Start () 
	{
		FindPlayers();
	}

	void Update ()
	{
		//FindPlayers();
	}

	public void FindPlayers()
	{
		getAllPlayers = GameObject.FindGameObjectsWithTag("Player");

		foreach (GameObject player in getAllPlayers) 
		{

			if(player.name == "Erika")
			{
				allPlayers[0] = player;

			}
			if(player.name == "Amy")
			{
				allPlayers[1] = player;
			}
			else if(player.name == "Claire")
			{
				allPlayers[1] = player;
			}
		}
	}
}
