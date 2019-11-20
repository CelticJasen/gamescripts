using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingEffect : MonoBehaviour
{
	private bool recovering = false;
	private bool shieldUse = false;
	private float shieldHealth;
	[SerializeField]
	[Tooltip("Maximum shield health")]
	private float maxShieldHealth;
	[SerializeField]
	[Tooltip("The reference to the shield game object")]
	private GameObject shieldObject;


	// Use this for initialization
	void Start ()
	{
		shieldHealth = Mathf.Clamp (shieldHealth, 0, maxShieldHealth);

		if (shieldHealth <= 0)
		{
			ShieldDown ();
		}

		if (!shieldUse && !recovering)
		{
			StartCoroutine (RegenerateHealth(shieldHealth));
		}
	}

	public void DamageShield(float damage)
	{
		shieldHealth -= damage;
	}

	private void ShieldUp()
	{
		shieldObject.GetComponent<MeshCollider> ().enabled = true;
		shieldUse = true;
	}
	
	private void ShieldDown()
	{
		shieldObject.GetComponent<MeshCollider> ().enabled = false;
		shieldUse = false;
	}

	private IEnumerator RegenerateHealth(float shieldHealth)
	{
		recovering = true;
		yield return new WaitForSeconds (0.1f);
		shieldHealth += 1;
		recovering = false;
	}
}