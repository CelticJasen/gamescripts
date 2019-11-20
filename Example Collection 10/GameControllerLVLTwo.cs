using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.Audio;

public class GameControllerLVLTwo : MonoBehaviour
{
	// Declare variables here
	public int playerLives = 3;
	public Vector3 respawnLocation;
	private GameObject thePlayer;
	private Vector3 thePlayerPosition;
	public AudioSource gameMusic;
	public AudioClip bossMusic;

	public GameObject[] alarms = new GameObject[10];

	public Button respawnButton;
	public Button winButton;
	public Button trueWinButton;

	public Image[] lives = new Image[3];

	public GameObject bossHealth;

	public bool allDead = false;
	public bool boss = false;

	public float bossHealthValue = 500;

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

		// If player lives is 2 then lives image 2 will be disabled
		if (playerLives == 2)
		{
			lives [2].enabled = false;
		}

		// If player lives is 1 then lives image 1 and 2 will be disabled
		if (playerLives == 1)
		{
			lives [1].enabled = false;
			lives [2].enabled = false;
		}

		// Calls Check Aliens function
		CheckAliens ();

		// If all enemies are dead and the boss has not been summoned, display the win button
		if (allDead == true)
		{
			if (boss == false)
			{
				WinButton ();
			}
		}

		// If the player has no flight and the boss has been summoned, enable flight
		if (thePlayer.GetComponent<Flight> ().enabled == false && boss == true)
		{
			thePlayer.GetComponent<Flight> ().enabled = true;
		}

		// If the boss has been summoned and the boss music isn't already playing, play the boss music
		if (boss == true)
		{
			if (gameMusic.clip != bossMusic)
			{
				bossHealth.SetActive(true);
				gameMusic.clip = bossMusic;
				gameMusic.Play ();
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
			if (alarm != null)
			{
				alarm.GetComponent<Alarm> ().StopAlarm ();
			}
		}
		// Sets the cursor to invisible again
		Cursor.visible = false;
		// Locks the cursor to the middle of the screen
		Cursor.lockState = CursorLockMode.Locked;
		// Re-enables the FirstPersonController script
		thePlayer.GetComponent<FirstPersonController> ().enabled = true;
		thePlayer.GetComponent<GunControlsLVL2> ().enabled = true;
		// Sets the respawn button to not be there again
		respawnButton.interactable = false;
	}

	// Function that changes the boss' health meter width according to how much health it has
	public void ChangeBossHealthMeter()
	{
		bossHealth.GetComponent<Image> ().rectTransform.sizeDelta = new Vector2 (bossHealthValue, 10);
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
		thePlayer.GetComponent<GunControlsLVL2> ().enabled = false;
	}

	// Call this to make the win button appear
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
		thePlayer.GetComponent<GunControlsLVL2> ().enabled = false;
	}

	// Call this to make the true win button appear
	public void TrueWinButton()
	{
		// Makes the respawn button be there
		trueWinButton.interactable = true;
		// Makes the cursor visible
		Cursor.visible = true;
		// Unlocks the cursor
		Cursor.lockState = CursorLockMode.None;
		// Disables the FirstPersonController script
		thePlayer.GetComponent<FirstPersonController> ().enabled = false;
		thePlayer.GetComponent<GunControlsLVL2> ().enabled = false;
	}

	// Call this to make the alarms go off
	public void SoundAlarms()
	{
		// Call the SoundAlarm functions in all Alarm scripts on the sirens
		foreach (GameObject alarm in alarms)
		{
			if (alarm != null)
			{
				alarm.GetComponent<Alarm> ().SoundAlarm ();
			}
		}
	}

	// Call this to go to the victory scene
	public void WinEvent()
	{
		// Loads the victory scene
		SceneManager.LoadScene ("Winner");
	}

	// Call this to send the player to the true win scene
	public void TrueWinEvent()
	{
		SceneManager.LoadScene ("TrueWinner");
	}

	// Call this to see if all aliens have been killed
	public void CheckAliens()
	{
		foreach (GameObject alarm in alarms)
		{
			if (alarm != null)
			{
				allDead = false;
				return;
			}
		}

		allDead = true;
		return;
	}
}