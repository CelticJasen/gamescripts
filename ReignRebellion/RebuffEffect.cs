using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebuffEffect : AbilityRaycast
{
	private List<GameObject> enemyPlayers = new List<GameObject>();
	private GameObject[] allPlayers;

	[Header("Ability Values")]
	[Tooltip("The amount of force this ability with use to push enemies away")]
	[SerializeField]
	private float repelForce;
	[Tooltip("The radius of the collider for the spawned shield prefab")]
	[SerializeField]
	private float shieldRadius;
	[Tooltip("The shield prefab")]
	[SerializeField]
	private GameObject shieldPrefab;
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

	void Update ()
	{
		
	}

	// Call this once to use Rebuff on the caster
	public void RebuffSelf()
	{
		//TODO: Make a game object a child of the player that has a collider that will destroy any incoming projectiles
		GameObject shield = Instantiate(shieldPrefab);
		shield.transform.parent = gameObject.transform;
		shield.GetComponent<SphereCollider> ().radius = shieldRadius;
		shield.GetComponent<RebuffShield>().SetTeam(myTeam);
	}

	// Call this once to attempt to use Rebuff on an enemy
	public void RebuffEnemy()
	{
		foreach(GameObject target in enemyPlayers)
		{
			if (CanSee(target) == true)
			{
				Vector3 forceDirection = gameObject.transform.position - target.gameObject.transform.position;

				target.gameObject.GetComponent<Rigidbody>().AddForce(-forceDirection * repelForce);
			}
		}
	}
}