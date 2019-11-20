using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	public int damage = 1;
	public float speed = 150f;
	private Vector3 mouse;
	private float rotationZ;
	private Vector3 difference;
	public AudioClip daggerHit;
	private AudioSource audioSource;

	// Use this for initialization
	void Start ()
	{
		Destroy(gameObject, 0.75f);
		mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		difference = mouse - transform.position;
		mouse = mouse - transform.position;
		mouse = transform.position + mouse.normalized * 5000;
		audioSource = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		transform.position = Vector2.MoveTowards(transform.position, mouse, speed * Time.deltaTime);
		transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Monster" && other is BoxCollider2D)
		{
			other.gameObject.GetComponent<BlobController>().blobHealth -= 1;
			audioSource.PlayOneShot(daggerHit);
			Destroy(gameObject);
		}
	}
}