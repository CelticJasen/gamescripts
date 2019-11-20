using UnityEngine;
using System.Collections;

public class WinSpot : MonoBehaviour
{
	public GameObject gameController;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	// Called when an object collides with this collider
	void OnTriggerEnter(Collider other)
	{
		// If the collided object is player and documents bool in the GameController script is set to true
		if (other.gameObject.tag == "Player")
		{
			// Calls the CheckDocuments function in GameController script
			gameController.GetComponent<GameController> ().CheckDocuments ();

			// If hasAll bool from GameController script is true
			if (gameController.GetComponent<GameController> ().hasAll == true)
			{
				// Calls the WinEvent function in the GameController script
				GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().WinButton ();
			}
		}
	}
}