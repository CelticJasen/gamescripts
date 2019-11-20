using UnityEngine;
using System.Collections;

public class HealDrop : MonoBehaviour
{
	private AudioSource audioSource;
	public AudioClip healUp;

	// Use this for initialization
	void Start ()
	{
		audioSource = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Rogue" && other is BoxCollider2D)
		{
			other.gameObject.GetComponent<Movement>().rogueHealth += 2;
			audioSource.PlayOneShot(healUp);
			Destroy(gameObject);
		}
	}
}