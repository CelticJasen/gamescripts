using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPCDialog : MonoBehaviour {

	public TextAsset textFile; // Variable for the text file
	public string[] dialogLines = new string[10]; // Array for all the lines of text in the text file
	public int lineNumber; // Variable for which line of text you're on
	public string dialog; // Variable that holds the current line of text in the text file

	public GameObject dialogCanvas; // This variable holds a reference to the canvas game object
	public Text uiText; // This variable holds a reference to the Text UI under the canvas game object
	public GameObject heartIcon; // This variable holds a reference to the HeartIcon game object under the canvas
	public GameObject textBox; // This variable holds a reference to the Image on the Canvas

	public float delay = 0.02f; // At this speed it'll show 20 characters per second
	public int currentPosition = 0;

	public bool typing = true;

	// Use this for initialization
	void Start ()
	{
		dialogCanvas = GameObject.FindGameObjectWithTag ("Dialog"); // Finds the canvas game object and assigns it to the dialogCanvas variable
		heartIcon = GameObject.FindGameObjectWithTag ("HeartIcon"); // Finds the HeartIcon game object and assigns it to the heartIcon variable
		textBox = GameObject.FindGameObjectWithTag ("TextBox"); // Finds the Image game object and assigns it to the textBox variable

		if (textFile) // Checks to see if there's a text file reference
		{
			dialogLines = (textFile.text.Split ("\n"[0])); // Splits the text file into lines and assigns them to an array
		}

		if (lineNumber < 0)
		{
			lineNumber = 0; // Sets lineNumber to 0 if for some reason it's set to a negative number
		}

		dialog = dialogLines [lineNumber];
		StartCoroutine (TypeMessage ());
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (dialog.Contains("~"))
		{
			textBox.GetComponent<Image>().enabled = false; // Turns off the image game object so the text box and text won't show on screen anymore and this script won't run anymore
			heartIcon.GetComponent<Image>().enabled = false; // Turns off the heart icon game object
			GameObject.FindGameObjectWithTag ("Text").GetComponent<Text>().enabled = false;
		}

		if (Input.GetKeyDown (KeyCode.Space) && typing == false) // If space is pressed
		{
			typing = true;
			uiText.text = "";
			Next (); // Call to the "Next" function
			dialog = dialogLines[lineNumber]; // Sets dialog variable to the current line of text in the text file
			StartCoroutine(TypeMessage());
		}

		if (typing == false)
		{
			heartIcon.GetComponent<Image>().enabled = true;
			if (dialog.Contains("~"))
			{
				heartIcon.GetComponent<Image>().enabled = false;
			}
		}

		if (typing == true)
		{
			heartIcon.GetComponent<Image>().enabled = false;
		}
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