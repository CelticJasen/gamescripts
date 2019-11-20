//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class MedicalDeviceEffect : AbilityRaycast
//{
//	private List<GameObject> enemyPlayers = new List<GameObject>();
//	private List<GameObject> allyPlayers = new List<GameObject>();
//	private GameObject[] allPlayers;
//
//	[Header("Ability Values")]
//	[Tooltip("Amount of damage to enemy magic")]
//	[SerializeField]
//	private float damageMagicAmount;
//	[Tooltip("Amound of health recovered if used on an ally")]
//	[SerializeField]
//	private float recoveryAmount;
//	[Tooltip("The name tag of this player's team")]
//	[SerializeField]
//	public string myTeam;
//
//	void Start ()
//	{
//		//Get all the players and sticks them into the allPlayers array
//		allPlayers = GameObject.FindGameObjectsWithTag ("Player");
//
//		//Figure out which players in allPlayers is on the opposite team and assign them to a location in enemyPlayers array
//		foreach (GameObject player in allPlayers)
//		{
//			if (!player.GetComponent<Tags> ().HasTag (myTeam))
//			{
//				enemyPlayers.Add(player);
//			}
//
//			if (player.GetComponent<Tags> ().HasTag (myTeam))
//			{
//				allyPlayers.Add(player);
//			}
//		}
//	}
//	
//	public void UseMedicalDevice ()
//	{
//		foreach(GameObject target in enemyPlayers)
//		{
//			if (CanSee(target) == true)
//			{
//				target.GetComponent<PlayerManager>().currentHealth -= damageMagicAmount;
//				gameObject.GetComponent<PlayerManager> ().currentHealth += recoveryAmount;
//			}
//		}
//
//		foreach(GameObject target in allyPlayers)
//		{
//			if (CanSee(target) == true)
//			{
//				target.GetComponent<PlayerManager>().currentHealth += recoveryAmount;
//			}
//		}
//	}
//}