using UnityEngine;
using System.Collections;

public class PlayerTrigger : MonoBehaviour
{
	public GameObject myDocument;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	// Called when player enters the collider and sets the inRange bool to true
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player" && myDocument != null)
		{
			myDocument.GetComponent<MouseOverInteract>().inRange = true;
		}
	}

	// Called when player exits the collider and sets value to false
	public void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player" && myDocument != null)
		{
			myDocument.GetComponent<MouseOverInteract>().inRange = false;
		}
	}
}