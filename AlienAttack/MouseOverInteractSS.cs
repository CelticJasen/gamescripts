using UnityEngine;
using System.Collections;

public class MouseOverInteractSS : MonoBehaviour
{
	public bool inRange = false;
	public AudioSource sphereSound;
	public GameObject bossPrefab;
	public GameObject gameController;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	// Call this to summon boss if player is in range and presses E
	public void OnMouseOver()
	{
		if (Input.GetKeyDown (KeyCode.E) && inRange == true)
		{
			gameController.GetComponent<GameControllerLVLTwo> ().boss = true;
			Instantiate (bossPrefab);
			sphereSound.Play();
			Destroy (gameObject);
		}
	}
}