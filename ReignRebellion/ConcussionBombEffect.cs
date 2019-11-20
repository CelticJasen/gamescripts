using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcussionBombEffect : AbilityRaycast
{
	private List<GameObject> enemyPlayers = new List<GameObject>();
	private GameObject[] allPlayers;

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
		}
	}

	public void UseLifeForce ()
	{
		//Sends each player in enemyPlayers through the raycast script and returns true if they are and does damage to them and heals caster
		foreach(GameObject target in enemyPlayers)
		{
			if (CanSee(target) == true)
			{
				//Code for this to work will need to be written in the player's controller script
//				target.GetComponent<PlayerController> ().disableMovement = true;
				StartCoroutine (ReEnableMovement (target));
			}
		}
	}

	private IEnumerator ReEnableMovement(GameObject target)
	{
		yield return new WaitForSeconds (2);
		//Code for this to work will need to be written in the player's controller script
//		target.GetComponent<PlayerController> ().disableMovement = true;
	}
}