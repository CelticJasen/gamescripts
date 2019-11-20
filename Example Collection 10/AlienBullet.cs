using UnityEngine;
using System.Collections;

public class AlienBullet : MonoBehaviour
{
	private GameObject thePlayer;
	private GameObject gameController;
	private AudioSource playerHurt;
	float timer = 0.0f;

	// Use this for initialization
	void Start ()
	{
		thePlayer = GameObject.FindGameObjectWithTag ("Player");
		gameController = GameObject.FindGameObjectWithTag ("GameController");
		playerHurt = GameObject.FindGameObjectWithTag ("PlayerHurtSound").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		gameObject.GetComponent<Rigidbody> ().AddForce ((thePlayer.transform.position - gameObject.transform.position) * 25 * Time.smoothDeltaTime);
		gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, thePlayer.transform.position, 0.5f);

		if (timer >= 5)
		{
			Destroy (gameObject);
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			gameController.GetComponent<GameControllerLVLTwo> ().playerLives -= 1;
			playerHurt.Play ();
			Destroy (gameObject);
		}
	}
}