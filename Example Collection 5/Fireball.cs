using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	public float speed = 20.0f;
	public float delay = 4.0f;
	public GameObject player;
	public int damage = 1;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.left * speed * Time.deltaTime;
		Destroy (gameObject, delay);
	}

	void OnTriggerEnter2D (Collider2D player)
	{
		player.gameObject.GetComponent<Player>().DamagePlayer(damage);
		Destroy (gameObject);
	}
}