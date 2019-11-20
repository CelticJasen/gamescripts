using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class MagicMaceProjectile : MonoBehaviour
{
	private string myTeam;

	private float damage;

	public void SetDamage(float damage)
	{
		this.damage = damage;
	}

	public void SetTeam(string myTeam)
	{
		this.myTeam = myTeam;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!other.GetComponent<Tags>().HasTag(myTeam))
		{
			other.GetComponent<PlayerManager> ().currentHealth -= damage;
		}
		Destroy (gameObject);
	}
}