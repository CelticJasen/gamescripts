using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	// Declare all variables
	public int asteroidsInLevel = 0;
	public GameObject asteroid;
	private Vector3 randomPosition;
	public GameObject player;
	private int playerLives;
	private float randomX;
	private float randomY;
	public Button restartButton;
	public int asteroidsKilled = 0;
	public Text asteroidScore;
	public Text highScore;
	public int newHighscore;
	public int score;
	public string highScoreKey = "Highscore";

	// Use this for initialization
	void Start ()
	{
		// Get and set the high score to the newHighscore variable
		newHighscore = PlayerPrefs.GetInt(highScoreKey,0);

		// Sets the restart button to inactive at the start of the scene
		restartButton.interactable = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Get reference to player's lives variable on the PlayerControls script and sets it to playerLives variable
		playerLives = player.GetComponent<PlayerControls> ().playerLives;

		// Creates an array to hold a reference to all the asteroids currently in the scene
		GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
		// Sets a variable to hold a reference to how many asteriods there currently are in the scene
		asteroidsInLevel = asteroids.Length;

		// If there are less than 3 asteroids in the level and the player character is active
		if (asteroidsInLevel < 3 && player.activeSelf == true)
		{
			// Stores a random value between 9 and -9 in the randomX and randomY variables
			randomX = Random.Range (9, -9);
			randomY = Random.Range (9, -9);

			// These if/else statements add or subtract to the values held in randomX and randomY
			if (randomX <= 0)
			{
				randomX = randomX - 11;
			}
			else
			{
				randomX = randomX + 11;
			}

			if (randomY <= 0)
			{
				randomY = randomY - 11;
			}
			else
			{
				randomY = randomY + 11;
			}

			// Uses randomX and randomY to randomly place the asteroids a certain distance out of the players view
			randomPosition = new Vector3(randomX, randomY, 0);
			Instantiate(asteroid, randomPosition, Quaternion.Euler(0, 0, 0));
		}

		// If the player character is not active
		if (player.activeSelf == false)
		{
			// If space is pressed while the player still has lives
			if (Input.GetKeyDown (KeyCode.Space) && playerLives > 0)
			{
				// Sets the player character to active again
				player.SetActive (true);
			}
		}

		// If the player has no more lives
		if (playerLives < 1)
		{
			// If the current score is higher than the high score
			if(score > newHighscore)
			{
				// Sets playerprefs to hold the new high score
				PlayerPrefs.SetInt(highScoreKey, score);
				PlayerPrefs.Save();
			}

			// Activates the restart button
			restartButton.interactable = true;
		}

		// Sets the scores to their relevant values
		score = asteroidsKilled;
		asteroidScore.text = "Score: " + asteroidsKilled;
		highScore.text = "Best: " + newHighscore;

		// If the player presses escape
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			// Application is closed
			Application.Quit ();
		}
	}

	// Call this when you want to restart the game
	public void RestartGame()
	{
		// Loads the start screen
		SceneManager.LoadScene ("StartScreen");
	}
}