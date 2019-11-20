using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingEffect : MonoBehaviour
{
	private float shieldHealth;


	// Use this for initialization
	void Start ()
	{
		gameObject.GetComponent<PlayerManager> ().canTakeDamage = false;
	}
	
	private void ShieldDown()
	{
		gameObject.GetComponent<PlayerManager> ().canTakeDamage = true;
	}
}