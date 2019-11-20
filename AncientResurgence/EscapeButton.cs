using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EscapeButton : MonoBehaviour {

	public Button quitButton;
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			quitButton.image.enabled = !quitButton.image.enabled;
			quitButton.enabled = !quitButton.enabled;
		}
	}
}