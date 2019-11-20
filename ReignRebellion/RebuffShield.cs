using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebuffShield : MonoBehaviour
{
	private string myTeam;

	public void SetTeam(string myTeam)
	{
		this.myTeam = myTeam;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!other.GetComponent<Tags>().HasTag(myTeam) && other.gameObject.tag == "Projectile") //This might need to be changed if projectiles won't have team tags
		{
			Destroy (other);
		}
	}
}