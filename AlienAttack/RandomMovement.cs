using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RandomMovement : MonoBehaviour
{

	public float velocidadMax;

	public float xMax;
	public float zMax;
	public float xMin;
	public float zMin;

	private float x;
	private float z;
	private float tempo;

	Scene currentScene;
	public AudioSource alienDeath;

	// Use this for initialization
	void Start ()
	{
		x = Random.Range(-velocidadMax, velocidadMax);
		z = Random.Range(-velocidadMax, velocidadMax);
		currentScene = SceneManager.GetActiveScene ();
	}

	// Update is called once per frame
	void Update ()
	{

		tempo += Time.deltaTime;

		if (transform.localPosition.x > xMax)
		{
			x = Random.Range(-velocidadMax, 0.0f);
			tempo = 0.0f; 
		}
		if (transform.localPosition.x < xMin)
		{
			x = Random.Range(0.0f, velocidadMax);
			tempo = 0.0f; 
		}
		if (transform.localPosition.z > zMax)
		{
			z = Random.Range(-velocidadMax, 0.0f);
			tempo = 0.0f; 
		}
		if (transform.localPosition.z < zMin)
		{
			z = Random.Range(0.0f, velocidadMax);
			tempo = 0.0f; 
		}


		if (tempo > 1.0f)
		{
			x = Random.Range(-velocidadMax, velocidadMax);
			z = Random.Range(-velocidadMax, velocidadMax);
			tempo = 0.0f;
		}

		transform.localPosition = new Vector3(transform.localPosition.x + x, transform.localPosition.y, transform.localPosition.z + z);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Bullet" && currentScene.name == "LevelOne")
		{
			Destroy (this);
		}

		if (other.gameObject.tag == "Bullet" && currentScene.name == "LevelTwo")
		{
			alienDeath.Play ();
			Destroy (gameObject);
		}
	}
}