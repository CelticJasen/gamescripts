using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class GameController : MonoBehaviour
{
	// Declare variables here
	public int playerLives = 3;
	public Vector3 respawnLocation;
	private GameObject thePlayer;
	private Vector3 thePlayerPosition;

	public GameObject[] alarms = new GameObject[10];

	public Button respawnButton;
	public Button winButton;

	public bool[] documents = new bool [10];

	public bool hasAll = false;

	public Image[] lives = new Image[3];

	public Image[] docs = new Image[10];

	private int docCount = 10;

	// Use this for initialization
	void Start ()
	{
		// Gets a reference to the player object
		thePlayer = GameObject.FindGameObjectWithTag ("Player");
		// Sets the respawn button to not be there
		respawnButton.interactable = false;
		// Sets the respawn position to the starting point
		respawnLocation = thePlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// If the player has lost all of their lives
		if (playerLives <= 0)
		{
			// Load the game over scene
			SceneManager.LoadScene ("GameOver");
		}

		// If esc is pressed
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			// Send player to the main menu
			SceneManager.LoadScene ("MainMenu");
		}

		// If the player has 2 lives
		if (playerLives == 2)
		{
			// Disable the second life image
			lives [2].enabled = false;
		}

		// If the player has 1 life
		if (playerLives == 1)
		{
			// Disable the first life image
			lives [1].enabled = false;
		}

		// Checks each element in the documents array if they are true and if they are true, enables the image with corresponding number
		for(int i = 0; i < docCount; i++)
		{
			if(documents[i] == true)
			{
				docs [i].enabled = true;
			}
		}
	}

	// Call this to respawn the player
	public void RespawnPlayer()
	{
		// Teleports the player to the last save spot
		thePlayer.transform.position = respawnLocation;
		// Decreases the player's lives by 1
		playerLives -= 1;
		// Calls the funcion in all the Alarm scripts to get them to shut up
		foreach (GameObject alarm in alarms)
		{
			alarm.GetComponent<Alarm> ().StopAlarm ();
		}
		// Sets the cursor to invisible again
		Cursor.visible = false;
		// Locks the cursor to the middle of the screen
		Cursor.lockState = CursorLockMode.Locked;
		// Re-enables the FirstPersonController script
		thePlayer.GetComponent<FirstPersonController> ().enabled = true;
		thePlayer.GetComponent<GunControls> ().enabled = true;
		// Sets the respawn button to not be there again
		respawnButton.interactable = false;
	}

	// Call this function to make the respawn button show up
	public void RespawnButton()
	{
		// Makes the respawn button be there
		respawnButton.interactable = true;
		// Makes the cursor visible
		Cursor.visible = true;
		// Unlocks the cursor
		Cursor.lockState = CursorLockMode.None;
		// Disables the FirstPersonController script
		thePlayer.GetComponent<FirstPersonController> ().enabled = false;
		thePlayer.GetComponent<GunControls> ().enabled = false;
	}

	// Call this to make the alarms go off
	public void SoundAlarms()
	{
		// Call the SoundAlarm functions in all Alarm scripts on the sirens
		foreach (GameObject alarm in alarms)
		{
			alarm.GetComponent<Alarm> ().SoundAlarm ();
		}
	}

	public void WinButton()
	{
		// Makes the respawn button be there
		winButton.interactable = true;
		// Makes the cursor visible
		Cursor.visible = true;
		// Unlocks the cursor
		Cursor.lockState = CursorLockMode.None;
		// Disables the FirstPersonController script
		thePlayer.GetComponent<FirstPersonController> ().enabled = false;
		thePlayer.GetComponent<GunControls> ().enabled = false;
	}

	// Call this to go to the victory scene
	public void WinEvent()
	{
		// Loads the victory scene
		SceneManager.LoadScene ("LevelTwo");
	}

	public void TakeDocument(int docNumber)
	{
		documents [docNumber] = true;
	}

	// Checks each element in documents and if one is false then hasAll will be false. Otherwise it will return as true
	public void CheckDocuments()
	{
		foreach (bool document in documents)
		{
			if (document == false)
			{
				hasAll = false;
				return;
			}
		}

		hasAll = true;
		return;
	}
}