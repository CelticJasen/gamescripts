using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class InfoSceneButtons : MonoBehaviour
{

	public Button quitButton;
	public Button backButton;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{
			SceneManager.LoadScene("AgricultureMain");
		}
	}

	public void QuitPress()
	{
		Application.Quit ();
	}

	public void BackPress()
	{
		SceneManager.LoadScene("AgricultureMain");
	}
}