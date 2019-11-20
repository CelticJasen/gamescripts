using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public Button exitButton;
	public Button newGameButton;
	public Button tutorialButton;

	public void ExitPress()
	{
		Application.Quit ();
	}

	public void NewGamePress()
	{
		Application.LoadLevel("Library");
	}

	public void TutorialPress()
	{
		Application.LoadLevel("Tutorial");
	}
}