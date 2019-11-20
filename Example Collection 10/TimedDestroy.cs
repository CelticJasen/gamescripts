using UnityEngine;
using System.Collections;

public class TimedDestroy : MonoBehaviour
{
	public float timer = 0;
	public float expireTime = 5;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;

		if (timer >= expireTime)
		{
			Destroy (gameObject);
		}
	}
}