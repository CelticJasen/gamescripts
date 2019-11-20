using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeForceEffect : AbilityRaycast
{
	private List<GameObject> enemyPlayers = new List<GameObject>();
	private List<GameObject> allyPlayers = new List<GameObject>();
	private GameObject[] allPlayers;

	[Header("Ability Values")]
	[Tooltip("Amount of damage to enemies")]
	[SerializeField]
	private float damageAmount;
	[Tooltip("Amound of health recovered if used on an enemy")]
	[SerializeField]
	private float recoveryAmount;
	[Tooltip("Amount of health healed if used on an ally")]
	[SerializeField]
	private float allyHealAmount;
	[Tooltip("The name tag of this player's team")]
	[SerializeField]
	private string myTeam;

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

			if (player.GetComponent<Tags> ().HasTag (myTeam))
			{
				allyPlayers.Add(player);
			}
		}
	}

	public void UseLifeForce ()
	{
		//Sends each player in enemyPlayers through the raycast script and returns true if they are and does damage to them and heals caster
		foreach(GameObject target in enemyPlayers)
		{
			if (CanSee(target) == true)
			{
				target.GetComponent<PlayerManager>().currentHealth -= damageAmount;
				gameObject.GetComponent<PlayerManager> ().currentHealth += recoveryAmount;
			}
		}

		//Sends each player in allyPlayers through the raycast script and returns true if they are and does heals to them
		foreach(GameObject target in allyPlayers)
		{
			if (CanSee(target) == true)
			{
				target.GetComponent<PlayerManager>().currentHealth += allyHealAmount;
			}
		}
	}
}