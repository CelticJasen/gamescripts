using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	// Declare variables here
	public float speed = 0.05f;
	public AudioClip asteroidHit;
	private AudioSource audioSource;

	// Use this for initialization
	void Start ()
	{
		// Destroys this object after 1 second
		Destroy(gameObject, 1.0f);
		// Gets a reference to the audio source on the game manager and stores it in the audioSource variable
		audioSource = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Causes this object to move in the direction it's facing at a speed that can be set in the inspector
		transform.position += transform.right * speed * Time.deltaTime;
	}

	// This is called when this object enters the collider of another 2D object that has a collider
	void OnTriggerEnter2D(Collider2D other)
	{
		// If the collided object is an asteroid and has a 2D box collider
		if (other.gameObject.tag == "Asteroid" && other is BoxCollider2D)
		{
			// Sets the score of asteroids killed in the game managers script
			GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().asteroidsKilled += 1;
			// Plays the asteroid hit sound stored in asteroidHit variable
			audioSource.PlayOneShot(asteroidHit);
			// Destroys the asteroid
			Destroy (other.gameObject);
			// Destorys the object this script is on
			Destroy(gameObject);
		}
	}
}