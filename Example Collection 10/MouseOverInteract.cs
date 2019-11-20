using UnityEngine;
using System.Collections;

public class MouseOverInteract : MonoBehaviour
{
	public bool inRange = false;
	public int docNumber;
	public GameObject gameController;
	public AudioSource paperSound;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	// Call this to take document when player is in range of document and they press E
	public void OnMouseOver()
	{
		if (Input.GetKeyDown (KeyCode.E) && inRange == true)
		{
			gameController.GetComponent<GameController> ().TakeDocument (docNumber);
			paperSound.Play();
			Destroy (gameObject);
		}
	}
}