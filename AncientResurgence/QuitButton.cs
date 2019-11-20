using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{

	public Button exitButton;

	public void ExitPress()
	{
        SceneManager.LoadScene("MainMenu");
	}
}