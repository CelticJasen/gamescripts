using UnityEngine;
using System.Collections;

public class TriggerLoadLevel : MonoBehaviour
{
	public string Level;
	public Vector3 targetPosition;
	public Vector3 targetCameraPosition;
	public GameObject myCamera;
	public GameObject player;
	public BoxCollider2D Bounds;
	private GameObject boundaries;

	// Use this for initialization
	void Start () 
	{
		myCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		player = GameObject.FindGameObjectWithTag ("Player");
		boundaries = GameObject.FindGameObjectWithTag ("Boundaries");
		Bounds = boundaries.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnTriggerEnter2D (Collider2D Other)
	{
		if (Other.tag == "Player") 
		{
			myCamera.gameObject.GetComponent<Camera> ().farClipPlane = 5;
			boundaries.SetActive(false);
			player.transform.position = targetPosition;
			myCamera.transform.position = targetCameraPosition;
			Application.LoadLevel (Level);
		}
	}
}