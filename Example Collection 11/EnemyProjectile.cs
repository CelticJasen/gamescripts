using UnityEngine;
using System.Collections;

public class EnemyProjectile : MonoBehaviour
{
	public int damage = 1;
	public float speed = 100f;
	private Vector3 roguePosition;
	private AudioSource audioSource;
	public AudioClip blobHit;

	// Use this for initialization
	void Start ()
	{
		Destroy(gameObject, 0.75f);
		roguePosition = GameObject.FindGameObjectWithTag("Rogue").transform.position;
		roguePosition = roguePosition - transform.position;
		roguePosition = transform.position + roguePosition.normalized * 5000;
		audioSource = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector3.MoveTowards(transform.position, roguePosition, speed * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Rogue" && other is BoxCollider2D)
		{
			other.gameObject.GetComponent<Movement>().rogueHealth -= 1;
			audioSource.PlayOneShot(blobHit);
			Destroy(gameObject);
		}
	}
}