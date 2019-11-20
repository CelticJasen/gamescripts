using UnityEngine;
using System.Collections;

public class DoNotDestroy : MonoBehaviour
{
	public float delay = 0.0f;

	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	public void DestroyThisObject ()
	{
		Destroy(gameObject, delay);
	}
}