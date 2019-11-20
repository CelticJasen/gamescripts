using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
	public Button startButton;
	public Button quitButton;
	public Button creditsButton;

	public void QuitPress()
	{
		Application.Quit();
	}
	public void StartPress()
	{
		SceneManager.LoadScene("PewMain");
	}
	public void CreditPress()
	{
		SceneManager.LoadScene("Credits");
	}
}
