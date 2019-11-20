using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class OptionsValues : MonoBehaviour
{
	public AudioMixer mixer;
	public float masterVolume;
	public float musicVolume;
	public float soundVolume;
	public Scene currentScene;

	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	// Called each time level is loaded to set the volumes to the values the player chose in the options screen
	public void OnLevelWasLoaded()
	{
		mixer.SetFloat ("Master Volume", masterVolume);
		mixer.SetFloat ("Music Volume", musicVolume);
		mixer.SetFloat ("Sounds Volume", soundVolume);

		currentScene = SceneManager.GetActiveScene ();
	}

	// Call to destroy this object
	public void KillMe()
	{
		Destroy (gameObject);
	}
}