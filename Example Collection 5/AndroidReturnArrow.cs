using UnityEngine;
using System.Collections;

public class AndroidReturnArrow : MonoBehaviour {

	void Update ()
	{
		if (Input.GetKey (KeyCode.Escape))
		{
						Application.Quit ();
		}
	}
}