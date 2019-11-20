using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarnExitCollision : MonoBehaviour
{
	public GameObject player;
	private NPCDialog textDialogue;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		textDialogue = GameObject.FindGameObjectWithTag("Dialog").GetComponent<NPCDialog>();
	}

	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter2D (Collider2D Other)
	{
		if (Other.tag == "Player") 
		{
			textDialogue.TryingToLeaveTheBarnDialog();
			textDialogue.ActivateTextBox();
			textDialogue.StartTyping();
		}
	}
}