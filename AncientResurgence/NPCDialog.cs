using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCDialog : MonoBehaviour {

	public TextAsset textFile; // Variable for the text file
	public TextAsset rainComment;
	public TextAsset tryingToLeaveTheBarn;
	public string[] dialogLines = new string[10]; // Array for all the lines of text in the text file
	public int lineNumber; // Variable for which line of text you're on
	public string dialog; // Variable that holds the current line of text in the text file

	public GameObject dialogCanvas; // This variable holds a reference to the canvas game object
	public Text uiText; // This variable holds a reference to the Text UI under the canvas game object
	public GameObject heartIcon; // This variable holds a reference to the HeartIcon game object under the canvas
	public GameObject textBox; // This variable holds a reference to the Image on the Canvas
	public GameObject shakeCollision;

	public float delay = 0.02f; // At this speed it'll show 20 characters per second
	public int currentPosition = 0;

	public bool typing = true;

	public GameObject player;

	// Use this for initialization
	void Start ()
	{
		dialogCanvas = GameObject.FindGameObjectWithTag ("Dialog"); // Finds the canvas game object and assigns it to the dialogCanvas variable
		heartIcon = GameObject.FindGameObjectWithTag ("HeartIcon"); // Finds the HeartIcon game object and assigns it to the heartIcon variable
		textBox = GameObject.FindGameObjectWithTag ("TextBox"); // Finds the Image game object and assigns it to the textBox variable
		shakeCollision = GameObject.FindGameObjectWithTag("BarnShake"); //Finda the object with the collision for the barn shaking
		player = GameObject.FindGameObjectWithTag("Player");



		if (textFile) // Checks to see if there's a text file reference
		{
			dialogLines = (textFile.text.Split ("\n"[0])); // Splits the text file into lines and assigns them to an array
		}

		if (lineNumber < 0)
		{
			lineNumber = 0; // Sets lineNumber to 0 if for some reason it's set to a negative number
		}

		dialog = dialogLines [lineNumber];
		StartTyping();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (shakeCollision == null) 
		{
			shakeCollision = GameObject.FindGameObjectWithTag("BarnShake"); //Finda the object with the collision for the barn shaking
		}

		if (player == null)
		{
			player = GameObject.FindGameObjectWithTag ("Player");
		}
			
		if (shakeCollision != null) {
			if (dialog.Contains ("~") && shakeCollision.GetComponent<BarnShakeScript> ().isShaking == false) {
				textBox.GetComponent<Image> ().enabled = false; // Turns off the image game object so the text box and text won't show on screen anymore and this script won't run anymore
				heartIcon.GetComponent<Image> ().enabled = false; // Turns off the heart icon game object
				GameObject.FindGameObjectWithTag ("Text").GetComponent<Text> ().enabled = false;
				player.GetComponent<Movement> ().canMove = true;
			}
		} 
		else 
		{
			if (dialog.Contains ("~"))
			{
				textBox.GetComponent<Image>().enabled = false; // Turns off the image game object so the text box and text won't show on screen anymore and this script won't run anymore
				heartIcon.GetComponent<Image>().enabled = false; // Turns off the heart icon game object
				GameObject.FindGameObjectWithTag ("Text").GetComponent<Text>().enabled = false;
				player.GetComponent<Movement> ().canMove = true;
			}
		}


		if (Input.GetKeyDown (KeyCode.Space) && typing == false && dialog.Contains("~") == false) // If space is pressed and it's finished typing and it's not the end of the text document
		{
			typing = true;
			uiText.text = "";
			Next (); // Call to the "Next" function
			dialog = dialogLines[lineNumber]; // Sets dialog variable to the current line of text in the text file
			StartCoroutine(TypeMessage());
		}

		if (typing == false && dialog.Contains("~") == false)
		{
			heartIcon.GetComponent<Image>().enabled = true;
		}
		else if(typing == false && dialog.Contains("~") == true)
		{
			heartIcon.GetComponent<Image>().enabled = false;
		}

		if (typing == true)
		{
			heartIcon.GetComponent<Image>().enabled = false;
			player.GetComponent<Movement> ().canMove = false;
			player.GetComponent<Animator> ().SetBool ("IsIdle", true);
			player.GetComponent<Animator> ().SetBool ("IsWalking", false);
			player.GetComponent<Animator> ().SetBool ("IsRunning", false);

			if(GameObject.FindGameObjectWithTag ("Text").GetComponent<Text>().enabled == false)
			{
				ActivateTextBox();
			}
			if(textBox.GetComponent<Image>().enabled == false)
			{
				ActivateTextBox();
			}
		}
	}

	public void BarnSceneWasJustLoaded()
	{
		uiText.text = "";

		{
			if (rainComment) // Checks to see if there's a text file reference
			{
				dialogLines = (rainComment.text.Split ("\n"[0])); // Splits the text file into lines and assigns them to an array
				typing = true;
			}

			if (lineNumber != 0)
			{
				lineNumber = 0; // Sets lineNumber to 0 if for some reason it's set to a negative number
			}

			dialog = dialogLines [lineNumber];
		}
	}

	public void TryingToLeaveTheBarnDialog()
	{
		uiText.text = "";

		{
			if (tryingToLeaveTheBarn) // Checks to see if there's a text file reference
			{
				dialogLines = (tryingToLeaveTheBarn.text.Split ("\n"[0])); // Splits the text file into lines and assigns them to an array
				typing = true;
			}

			if (lineNumber != 0)
			{
				lineNumber = 0; // Sets lineNumber to 0 if for some reason it's set to a negative number
			}

			dialog = dialogLines [lineNumber];
		}
	}

	void OnLevelWasLoaded()
	{
		if (SceneManager.GetActiveScene().name == "DemoTunnel") 
		{
			
			if (player == null) 
			{
				player = GameObject.FindGameObjectWithTag("Player");
			}
		}
	}

	public void ActivateTextBox()
	{
		GameObject.FindGameObjectWithTag ("Text").GetComponent<Text>().enabled = true;
		textBox.GetComponent<Image>().enabled = true;
	}

	public void StartTyping()
	{
		StartCoroutine (TypeMessage ());
	}

	public void Next () // Call this method to go to the next line of text in the text file
	{
		lineNumber += 1; // Increases this variable by 1
	}

	IEnumerator TypeMessage ()
	{
		foreach (char letter in dialog.ToCharArray())
		{
			uiText.text += letter; // Puts the current line of text into the Text UI so it'll display on screen
			yield return new WaitForSeconds (delay);

			if (uiText.text == dialog)
			{
				typing = false;
			}
		}
	}
}