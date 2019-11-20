using UnityEngine;
using System.Collections;

public class ClimbTrigger : MonoBehaviour
{

	public GameObject thePlayer;
	public GameObject amySprite;
	GameObject[] playersArray;

	// Use this for initialization
	void Start ()
	{
		thePlayer = GameObject.FindGameObjectWithTag ("Player");
		amySprite = GameObject.FindGameObjectWithTag("Amy");
		playersArray = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CheckForCharacters>().allPlayers;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter2D (Collider2D Other)
	{
		foreach (GameObject player in playersArray)
		{
			if (Other.tag == "Player")
			{
				Other.GetComponent<Movement>().isClimbing = true;
			}
		}
//		if (Other.name == "Erika")
//		{
//			Other.GetComponent<Movement>().isClimbing = true;
//		}
//		if (Other.name == "Amy") 
//		{
//			Other.GetComponent<Movement>().isClimbing = true;
//		}
	}

	void OnTriggerExit2D (Collider2D Other)
	{
		foreach (GameObject player in playersArray)
		{
			if(Other.tag == "Player")
			{
				Other.GetComponent<Movement>().isClimbing = false;
			}
		}
//		if (Other.name == "Erika")
//		{
//			Other.GetComponent<Movement>().isClimbing = false;
//		}
//		if (Other.name == "Amy") 
//		{
//			Other.GetComponent<Movement>().isClimbing = false;
//		}
	}
}