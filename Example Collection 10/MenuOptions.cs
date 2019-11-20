using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuOptions : MonoBehaviour
{
	public GameObject optionsValues;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	// Sets the master volume to the dynamic float volume of the slider
	public void SetMasterVolume(float volume)
	{
		optionsValues.GetComponent<OptionsValues> ().masterVolume = volume;
	}

	// Sets the music volume to the dynamic float volume of the slider
	public void SetMusicVolume(float volume)
	{
		optionsValues.GetComponent<OptionsValues> ().musicVolume = volume;
	}

	// Sets the sound volume to the dynamic float volume of the slider
	public void SetSoundsVolume(float volume)
	{
		optionsValues.GetComponent<OptionsValues> ().soundVolume = volume;
	}
}