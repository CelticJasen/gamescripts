using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuitButton : MonoBehaviour
{

	public Button exitButton;

	public void ExitPress()
	{
		Application.LoadLevel("MainMenu");
	}
}