using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void StartGame()
	{
		SceneManager.LoadScene ("Game1");
	}

	public void RestartGame()
	{
		SceneManager.LoadScene ("MainMenu");
	}

	public void QuitGame()
	{
		Application.Quit ();
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}
}