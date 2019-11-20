using UnityEngine;
using System.Collections;

public class GunControls : MonoBehaviour
{
	// This is where I'm declaring my variables
	public AudioClip powerUp;
	public AudioClip powerUpFull;
	public AudioClip shoot;
	public AudioClip reload;
	public AudioSource gunSoundSource;

	private float powerUpTime = 0;
	private float powerPercentage;
	public float powerUpRate = 1;
	public float maxPower = 365;
	public float minPower = 10;
	public float power = 0;

	public float rotateSpeed = 1.0f;

	private bool canFire = true;

	public GameObject bullet;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Plays the power up sound when player presses down the left mouse button
		if (Input.GetMouseButtonDown(0) && canFire)
		{
			PlayPowerUpSound();
		}

		// Once the player has powered up for 4.5 seconds, power up full sound will replace the power up sound and make it so player can't fireuntil reloading
		if (Input.GetMouseButton (0) && canFire)
		{
			powerUpTime += Time.deltaTime * powerUpRate;

			if (powerUpTime > 4.5)
			{
				PlayPowerUpFullSound();
				canFire = false;
			}
		}

		// Fires the projectile after lifting the left mouse button and there has been some power up time
		if (Input.GetMouseButtonUp(0) && powerUpTime > 0)
		{
			PlayShootSound();
			FireProjectile();
			powerUpTime = 0;
			canFire = false;
		}

		// This is to reload when right mouse button is pressed down and released
		if (Input.GetMouseButtonUp(1))
		{
			canFire = true;
			PlayReloadSound();
		}

		powerPercentage = powerUpTime / 4.5f;

		power = powerPercentage * maxPower;
	}

	// Function that plays the power up sound
	private void PlayPowerUpSound()
	{
		gunSoundSource.clip = powerUp;
		gunSoundSource.Play ();
	}

	// Function that plays the power up full sound on loop
	private void PlayPowerUpFullSound()
	{
		gunSoundSource.loop = true;
		gunSoundSource.clip = powerUpFull;
		gunSoundSource.Play();
	}

	// Function that plays the shoot sound
	private void PlayShootSound()
	{
		gunSoundSource.loop = false;
		gunSoundSource.clip = shoot;
		gunSoundSource.Play();
		powerUpTime = 0;
	}

	// Function that plays the reload sound
	private void PlayReloadSound()
	{
		gunSoundSource.loop = false;
		gunSoundSource.clip = reload;
		gunSoundSource.Play();
	}

	// Call this to fire a bullet in the direction the player is facing and from the player's position
	private void FireProjectile()
	{
		GameObject theBullet;
		theBullet = Instantiate (bullet, GetComponentInChildren<Camera> ().transform.position + GetComponentInChildren<Camera> ().transform.forward, GetComponentInChildren<Camera> ().transform.rotation) as GameObject;
		theBullet.GetComponent<Rigidbody> ().AddForce (power * GetComponentInChildren<Camera> ().transform.forward);
	}
}