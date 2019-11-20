using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		// Makes the cursor visible
		Cursor.visible = true;
		// Unlocks the cursor
		Cursor.lockState = CursorLockMode.None;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	// Call this to send player to main menu
	public void MenuButtonPress()
	{
		SceneManager.LoadScene("MainMenu");
	}
}