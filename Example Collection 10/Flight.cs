using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class Flight : MonoBehaviour
{
	public float flySpeed = 50.0f;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		// If the player is holding down spacebar
		if (Input.GetKey (KeyCode.Space))
		{
			// Calls to the FirstPersonController script and sends the value in flySpeed to the Fly function
			gameObject.GetComponent<FirstPersonController> ().Fly (flySpeed);
			// Changes the walk speed in the first person controller script so the player moves much faster
			gameObject.GetComponent<FirstPersonController> ().m_WalkSpeed = 20;
			// Changes the run speed in the first person controller script so the player moves much faster
			gameObject.GetComponent<FirstPersonController> ().m_RunSpeed = 50;
		}
	}
}