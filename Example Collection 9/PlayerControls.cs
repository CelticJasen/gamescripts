using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{
	// Declare variables here
	public GameObject shipProjectile;
	private float canFireIn;
	private float fireRate = 0.2f;
	public float rotateSpeed = 1.0f;
	public int playerLives = 3;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Decreases the canFireIn variable according to amount of time passed
		canFireIn -= Time.deltaTime;

		// If the player presses Space
		if (Input.GetKey(KeyCode.Space))
		{
			// Calls to the FireProjectile funcion
			FireProjectile();
		}

		// If the player presses the left arrow key
		if (Input.GetKey (KeyCode.LeftArrow))
		{
			// Rotates this object at a speed that can be set in the inspector
			transform.Rotate (Vector3.forward * rotateSpeed * Time.deltaTime);
		}

		// If the player presses the right arrow key
		if (Input.GetKey (KeyCode.RightArrow))
		{
			// Rotates this object the other direction at a speed that can be set in the inspector
			transform.Rotate (Vector3.back * rotateSpeed * Time.deltaTime);
		}
	}

	// Call this if you want to fire a projectile from this object
	void FireProjectile()
	{
		// If the canFireIn variable is greater than zero
		if (canFireIn > 0)
		{
			// Exit this function
			return;
		}

		// Create a prefab of the game object that shipProjectile references
		Instantiate (shipProjectile, transform.position, transform.rotation);
		// Resets the canFireIn variable to the value held in fireRate variable
		canFireIn = fireRate;
	}
}