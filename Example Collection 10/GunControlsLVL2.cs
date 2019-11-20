using UnityEngine;
using System.Collections;

public class GunControlsLVL2 : MonoBehaviour
{
	// This is where I'm declaring my variables
	public AudioClip shoot;
	public AudioSource gunSoundSource;

	public float power = 5000;

	public float rotateSpeed = 1.0f;

	public GameObject bullet;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		// Once the player has powered up for 4.5 seconds, power up full sound will replace the power up sound and make it so player can't fireuntil reloading
		if (Input.GetMouseButton (0))
		{
			FireProjectile ();
			PlayShootSound ();
		}
	}

	// Function that plays the shoot sound
	private void PlayShootSound()
	{
		gunSoundSource.loop = false;
		gunSoundSource.clip = shoot;
		gunSoundSource.Play();
	}

	// Call this to fire a bullet from player position and facing
	private void FireProjectile()
	{
		GameObject theBullet;
		theBullet = Instantiate (bullet, GetComponentInChildren<Camera> ().transform.position + GetComponentInChildren<Camera> ().transform.forward, GetComponentInChildren<Camera> ().transform.rotation) as GameObject;
		theBullet.GetComponent<Rigidbody> ().AddForce (power * GetComponentInChildren<Camera> ().transform.forward);
	}
}