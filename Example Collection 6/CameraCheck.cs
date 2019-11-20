using UnityEngine;
using System.Collections;

public class CameraCheck : MonoBehaviour
{
	public GameObject myCamera;
	float cameraClip;

	// Use this for initialization
	void Start ()
	{
		myCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		cameraClip = myCamera.gameObject.GetComponent<Camera> ().farClipPlane;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Application.loadedLevel == Application.loadedLevel)
		{
			myCamera = GameObject.FindGameObjectWithTag ("MainCamera");
			cameraClip = myCamera.gameObject.GetComponent<Camera> ().farClipPlane;

			if (cameraClip < 11)
			{
				myCamera.gameObject.GetComponent<Camera> ().farClipPlane = 11;
			}
		}
	}
}