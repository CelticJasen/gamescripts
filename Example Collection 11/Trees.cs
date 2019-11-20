using UnityEngine;
using System.Collections;

public class Trees : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void OnTriggerEnter2D (Collider2D coll)
	{
		if (coll.gameObject.tag == "Dagger")
		{
			Destroy(coll.gameObject);
		}

		if (coll.gameObject.tag == "BlobPew")
		{
			Destroy(coll.gameObject);
		}
	}
}