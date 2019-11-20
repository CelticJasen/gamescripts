using UnityEngine;
using System.Collections;

public class BlobController : MonoBehaviour
{
	private Vector2 speed;
	private float timing;
	private Rigidbody2D blobBody;
	private Vector2 roguePosition;
	public float fireRate = 0.25f;
	private float canFireIn = 0;
	public GameObject projectileBlob;
	public GameObject healDrop;
	public int blobHealth = 10;
	private bool rogueInRange = false;
	public Vector3 blobDeathPosition;
	private GameObject rogue;
	public bool rogueInvis;
	public AudioClip blobDeath;
	private AudioSource audioSource;

	// Use this for initialization
	void Start ()
	{
		blobBody = GetComponent<Rigidbody2D>();
		speed = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100));
		timing = 0;
		rogue = GameObject.FindGameObjectWithTag("Rogue");
		audioSource = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		timing += Time.deltaTime;
		blobBody.MovePosition(blobBody.position + speed * Time.deltaTime);

		if (timing > Random.Range(0.2f, 1f))
		{
			ChangeDirection();
			timing = 0;
		}

		canFireIn += Time.deltaTime;

		if (canFireIn > fireRate && rogueInRange && rogue.GetComponent<Movement>().invis == false)
		{
			FireProjectile();
		}

		if (blobHealth < 1)
		{
			blobDeathPosition = transform.position;
			GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().blobsKilled += 1;
			GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().HealthDropChance(blobDeathPosition);

			audioSource.PlayOneShot(blobDeath);

			Destroy(gameObject);
		}
	}

	public void ChangeDirection()
	{
		speed = new Vector2(Random.Range(-100, 100), Random.Range(-100, 100));
	}

	public void FireProjectile()
	{
		Instantiate(projectileBlob, transform.position, Quaternion.Euler(0, 0, 0));
		canFireIn = 0f;
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Rogue")
		{
			rogueInRange = true;
		}
	}

	void OnTriggerExit2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "Rogue")
		{
			rogueInRange = false;
		}
	}
}