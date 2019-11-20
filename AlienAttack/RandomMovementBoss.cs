using UnityEngine;
using System.Collections;

public class RandomMovementBoss : MonoBehaviour
{

	public float velocidadMax;

	public float xMax;
	public float zMax;
	public float xMin;
	public float zMin;
	public float yMin;
	public float yMax;

	private float x;
	private float z;
	private float y;
	private float tempo;

	public int health = 500;

	private float timer = 0.0f;
	private float deadTimer = 0.0f;

	[SerializeField]private float bulletTimer = 0.0f;
	[SerializeField]private float startFiringTimer = 0.0f;
	[SerializeField]private float stopFiringTimer = 0.0f;

	public GameObject bossBody;

	private AudioSource alienBossDeath;
	private AudioSource sphereAlarm;
	private AudioSource bossHurt;

	public GameObject shrapnel;
	public GameObject alienBullet;

	private GameObject gameController;

	public bool bossDead = false;

	// Use this for initialization
	void Start ()
	{
		x = Random.Range(-velocidadMax, velocidadMax);
		z = Random.Range(-velocidadMax, velocidadMax);
		y = Random.Range(-velocidadMax, velocidadMax);

		alienBossDeath = GameObject.FindGameObjectWithTag ("BossDeathSound").GetComponent<AudioSource> ();
		bossHurt = GameObject.FindGameObjectWithTag ("BossHurtSound").GetComponent<AudioSource> ();
		sphereAlarm = GameObject.FindGameObjectWithTag ("SphereAlarm").GetComponent<AudioSource> ();
		gameController = GameObject.FindGameObjectWithTag ("GameController");
	}

	// Update is called once per frame
	void Update ()
	{

		tempo += Time.deltaTime;
		startFiringTimer += Time.deltaTime;

		// If the x position is greater than the max x value
		if (transform.localPosition.x > xMax)
		{
			// x is set to a random negative number
			x = Random.Range(-velocidadMax, 0.0f);
			tempo = 0.0f; 
		}
		// etc.
		if (transform.localPosition.x < xMin)
		{
			x = Random.Range(0.0f, velocidadMax);
			tempo = 0.0f; 
		}
		if (transform.localPosition.z > zMax)
		{
			z = Random.Range(-velocidadMax, 0.0f);
			tempo = 0.0f; 
		}
		if (transform.localPosition.z < zMin)
		{
			z = Random.Range(0.0f, velocidadMax);
			tempo = 0.0f; 
		}
		if (transform.localPosition.y > yMax)
		{
			y = Random.Range(-velocidadMax, 0.0f);
			tempo = 0.0f; 
		}
		if (transform.localPosition.y < yMin)
		{
			y = Random.Range(0.0f, velocidadMax);
			tempo = 0.0f; 
		}


		if (tempo > 1.0f)
		{
			x = Random.Range(-velocidadMax, velocidadMax);
			z = Random.Range(-velocidadMax, velocidadMax);
			y = Random.Range(-velocidadMax, velocidadMax);
			tempo = 0.0f;
		}

		transform.localPosition = new Vector3(transform.localPosition.x + x, transform.localPosition.y + y, transform.localPosition.z + z);

		// No time to comment the rest
		if (health <= 0 && timer < 1)
		{
			timer += Time.deltaTime;
			Explode ();
			bossDead = true;
		}

		if (startFiringTimer >= 4)
		{
			if (bossDead == false)
			{
				FireAway ();
			}
		}
		if (bossDead == true)
		{
			deadTimer += Time.deltaTime;
			if (deadTimer > 10)
			{
				gameController.GetComponent<GameControllerLVLTwo> ().TrueWinButton ();
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Bullet")
		{
			bossHurt.Play ();
			health -= 1;
			gameController.GetComponent<GameControllerLVLTwo> ().bossHealthValue = health;
			gameController.GetComponent<GameControllerLVLTwo> ().ChangeBossHealthMeter ();
		}
	}

	public void FireAway()
	{
		bulletTimer += Time.deltaTime;
		stopFiringTimer += Time.deltaTime;

		if (bulletTimer >= 0.2)
		{
			Instantiate (alienBullet, gameObject.transform.position, gameObject.transform.rotation);
			bulletTimer = 0;
		}

		if (stopFiringTimer >= 3)
		{
			stopFiringTimer = 0;
			startFiringTimer = 0;
		}
	}

	public void Explode()
	{
		if (bossBody != null)
		{
			alienBossDeath.Play ();
		}
		Instantiate (shrapnel, gameObject.transform.position, gameObject.transform.rotation);
		sphereAlarm.Stop ();
		Destroy (bossBody);
	}
}