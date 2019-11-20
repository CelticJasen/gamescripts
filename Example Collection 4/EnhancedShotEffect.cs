using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancedShotEffect : AbilityRaycast
{
	private List<GameObject> enemyPlayers = new List<GameObject>();
	private GameObject[] allPlayers;

	[Header("Ability Values")]
	[Tooltip("Amount of damage to enemy")]
	[SerializeField]
	private float damageAmount;

	[Tooltip("The name tag of this player's team")]
	[SerializeField]
	public string myTeam;

	void Start ()
	{
		//Get all the players and sticks them into the allPlayers array
		allPlayers = GameObject.FindGameObjectsWithTag ("Player");

		//Figure out which players in allPlayers is on the opposite team and assign them to a location in enemyPlayers array
		foreach (GameObject player in allPlayers)
		{
			if (!player.GetComponent<Tags> ().HasTag (myTeam))
			{
				enemyPlayers.Add(player);
			}
		}
	}
	
	public void UseEnhancedShot ()
	{
		//Sends each player in enemyPlayers through the raycast script and returns true if they are and does damage to them
		foreach(GameObject target in enemyPlayers)
		{
			if (CanSee(target) == true)
			{
				target.GetComponent<PlayerManager>().currentHealth -= damageAmount;
			}
		}
	}
}