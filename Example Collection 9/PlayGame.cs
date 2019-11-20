using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		// If player presses escape key
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			// Exit the application
			Application.Quit ();
		}
	}

	// Call this function if you want to start the game
	public void PlayTheGame()
	{
		// Loads the first scene of the game
		SceneManager.LoadScene("Game");
	}
}