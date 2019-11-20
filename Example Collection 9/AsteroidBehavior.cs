using UnityEngine;
using System.Collections;

public class AsteroidBehavior : MonoBehaviour
{
	// Declare variables here
	private Transform playerTransform;
	public float asteroidSpeed = 0.5f;
	private AudioSource audioSource;
	public AudioClip asteroidHit;

	// Use this for initialization
	void Start ()
	{
		// Get the player's transform and store it in variable playerTransform
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
		// Set this object's rotation to that of the player's current rotation
		transform.rotation = playerTransform.rotation;
		// Get a reference to the audio source on the game manager and store it in the audioSource variable
		audioSource = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Moves this object towards the player's position at a rate determined by the asteroidSpeed variable
		transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, asteroidSpeed * Time.deltaTime);

		// If this object reaches zero on x and y axis then remove this object from the game
		if(transform.position.x == 0 && transform.position.y == 0)
		{
			Destroy(gameObject);
		}
	}

	// Use this for when colliding with a 2D object collider
	void OnTriggerEnter2D(Collider2D other)
	{
		// When the collided object is the player and the player's collider is a polygon collider
		if (other.gameObject.tag == "Player" && other is PolygonCollider2D)
		{
			// Play the audio file stored in the asteroidHit variable that's assigned in the inspector
			audioSource.PlayOneShot(asteroidHit);
			// Gets hold of the player controller script on the player object and reduces playerLives by 1
			other.gameObject.GetComponent<PlayerControls> ().playerLives -= 1;
			// Sets the player object to inactive
			other.gameObject.SetActive (false);
			// Destroys the object this script is attached to
			Destroy(gameObject);
		}
	}
}