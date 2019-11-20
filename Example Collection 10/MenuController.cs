using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	GameObject menuOptions;
	GameObject optionsValues;

	// Use this for initialization
	void Start ()
	{
		// If there is menu options object, assign it to menuOptions variable
		if (GameObject.FindGameObjectWithTag ("MenuOptions") != null)
		{
			menuOptions = GameObject.FindGameObjectWithTag ("MenuOptions");
		}

		// If there is options values object, assign it to the variable
		if (GameObject.FindGameObjectWithTag ("OptionsValues") != null)
		{
			optionsValues = GameObject.FindGameObjectWithTag ("OptionsValues");
		}

		// Makes the cursor visible
		Cursor.visible = true;
		// Unlocks the cursor
		Cursor.lockState = CursorLockMode.None;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	// Call this to send player to first level
	public void LoadGame()
	{
		SceneManager.LoadScene ("LevelOne");
	}

	// Call this to kill the menu options and values if they exist and send player to the options screen
	public void LoadOptions()
	{
		if (menuOptions != null)
		{
			Destroy(menuOptions);
		}

		if (optionsValues != null)
		{
			Destroy (optionsValues);
		}

		SceneManager.LoadScene ("Options");
	}

	// Call this to send player to the instructions screen
	public void LoadInstructions()
	{
		SceneManager.LoadScene ("Instructions");
	}

	// Call this to quit the game
	public void ExitGame()
	{
		Application.Quit ();
	}
}