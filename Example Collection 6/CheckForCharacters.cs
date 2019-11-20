using UnityEngine;
using System.Collections;

public class CheckForCharacters : MonoBehaviour 
{

	[SerializeField]private GameObject[] getAllPlayers;
	public GameObject[] allPlayers = new GameObject[2];

	// Use this for initialization
	void Start () 
	{
		FindPlayers();
	}

	void Update ()
	{
		//FindPlayers();
	}

	private void FindPlayers()
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
		}
	}
}
