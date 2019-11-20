using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[Header("Player Settings")]
	[SerializeField] private Player playerPrefab;
	[SerializeField] private Transform playerSpawnPoint;
	[SerializeField] private float playerRespawnDelay = 3f;
	[SerializeField] private int playerLives = 3;

	private bool paused = false;
	public bool Paused { get { return paused; } }
	public int PlayerLives { get { return playerLives; } }
	public bool IsGameOver { get; private set; }
	public int EnemiesKilled { get; set; }

	private void Start()
	{
		SpawnPlayer ();
	}

	private void SpawnPlayer()
	{
		Toolbox.Player = Instantiate (playerPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation) as Player;
		Toolbox.Player.Health.events.onDie.AddListener (HandlePlayerDeath);
	}

	private void HandlePlayerDeath()
	{
		if (playerLives > 0)
		{
			Invoke ("SpawnPlayer", playerRespawnDelay);
			playerLives--;
		}
		else
		{
			IsGameOver = true;
			if (Paused)
			{
				Pause (false);
			}
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape) && !IsGameOver)
		{
			Pause (!paused);
		}

		if (EnemiesKilled > 3)
		{
			SceneManager.LoadScene ("WinScene");
		}
	}

	public void Pause(bool paused)
	{
		this.paused = paused;
		Time.timeScale = paused ? 0f : 1f;
	}

	public void Restart()
	{
		Pause (false);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	public void QuitGame()
	{
		Pause (false);
		SceneManager.LoadScene ("MainMenu");
	}
}