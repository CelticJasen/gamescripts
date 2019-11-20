using UnityEngine;
using System.Collections;

public class PlayerTriggerSS : MonoBehaviour
{
	public GameObject mySphere;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (mySphere != null)
			{
				mySphere.GetComponent<MouseOverInteractSS> ().inRange = true;
			}
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (mySphere != null)
			{
				mySphere.GetComponent<MouseOverInteractSS> ().inRange = false;
			}
		}
	}
}