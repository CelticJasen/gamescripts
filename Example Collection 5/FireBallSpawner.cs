using UnityEngine;
using System.Collections;

public class FireBallSpawner : MonoBehaviour {

	public GameObject fireBall;
	public int spawnDelay = 3;

	// Use this for initialization
	void Start () {
		Invoke("Spawn", spawnDelay);
	}
	
	// Update is called once per frame
	void Spawn () {
		//Vector3 position = new Vector3 (Transform.position.x, Random.Range (0.0f, 300.0f), Transform.position.z);
		Vector3 position = new Vector3(gameObject.transform.position.x, Random.Range (0.0f, 10.5f), gameObject.transform.position.z);
		Instantiate(fireBall, position, Quaternion.identity);
		Invoke("Spawn", spawnDelay);
	}
}