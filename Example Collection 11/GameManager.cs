using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public int enemiesInLevel = 0;
	public GameObject blobMonster;
	public GameObject bossMonster;
	private Vector3 randomPosition;
	private Vector3 bossPosition;
	public int blobsKilled = 0;
	public Text blobScore;
	private int healDropChance;
	public GameObject healDrop;
	public Vector3 blobDeathPosition;
	public Text highScore;
	public int newHighscore;
	public int score;
	public string highScoreKey = "Highscore";
	Rigidbody2D playerPosition; 

	// Use this for initialization
	void Start ()
	{
		//Get the highscore from player prefs if it is there, 0 otherwise
		newHighscore = PlayerPrefs.GetInt(highScoreKey,0);

		bossMonster = GameObject.FindGameObjectWithTag("Boss");
		//playerPosition = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().rogueBody;
	}
	
	// Update is called once per frame
	void Update ()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Monster");
		enemiesInLevel = enemies.Length;

		if (enemiesInLevel < 20)
		{
			randomPosition = new Vector3(Random.Range(50, 750), Random.Range(-750, -50), 0);
			Instantiate(blobMonster, randomPosition, Quaternion.Euler(0, 0, 0));
		}
		if(blobsKilled == 2)
		{
			bossPosition = new Vector3(Random.Range(50,750), Random.Range(-750, -50), 0);
			Instantiate(bossMonster, randomPosition, Quaternion.Euler(0,0,0));
		}
		score = blobsKilled;
			
		blobScore.text = "Score: " + blobsKilled;
		highScore.text = "Best: " + newHighscore;

	}

	void OnDisable()
	{
		//If our score is greater than highscore, set new highscore and save
		if(score > newHighscore)
		{
			PlayerPrefs.SetInt(highScoreKey, score);
			PlayerPrefs.Save();
		}
	}

	public void HealthDropChance(Vector3 blobDeathPosition)
	{
		healDropChance = Random.Range(1, 2);

		if (healDropChance == 1)
		{
			Instantiate(healDrop, blobDeathPosition, Quaternion.Euler(0, 0, 0));
		}
	}
}