using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashLoadWait : MonoBehaviour
{
	[SerializeField]
	[Tooltip("How long before loading the next scene.")]
	private float waitTime;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine (CountDown ());
	}

	IEnumerator CountDown()
	{
		yield return new WaitForSeconds (waitTime);
		LoadingScreenManager.LoadScene (2);
	}
}