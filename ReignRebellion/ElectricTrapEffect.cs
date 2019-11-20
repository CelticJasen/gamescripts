using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricTrapEffect : MonoBehaviour
{
	[Header("Ability Values")]
	[Tooltip("Radius of the ability's effect")]
	[SerializeField]
	private float effectRadius = 1;
	[Tooltip("The damage caused by the ability per second")]
	[SerializeField]
	private float damagePerSecond;
	[Tooltip("The name tag of this player's team")]
	[SerializeField]
	private string myTeam;

	private bool working = true;

    // Use this for initialization
    void Start ()
	{
		this.GetComponent<SphereCollider> ().radius = effectRadius;
	}

	private void OnTriggerStay(Collider other)
	{
		if (!other.GetComponent<Tags>().HasTag(myTeam))
		{
			//TODO: Add mana modifier to sap player's magic
			StartCoroutine (DamagePlayer (other));
		}
	}

	//Does damage every 0.1 second that adds up to the full damagePerSecond after each full second passes
	private IEnumerator DamagePlayer(Collider other)
	{
		if (working)
		{
			working = false;
			other.GetComponent<PlayerManager> ().currentHealth -= (damagePerSecond / 10);
			yield return new WaitForSeconds (0.1f);
			working = true;
		}
	}
}