using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class Alarm : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	// Call this to make this siren go off
	public void SoundAlarm()
	{
		// If this siren isn't already making noise
		if (!gameObject.GetComponent<AudioSource> ().isPlaying)
		{
			// Play the siren sound
			gameObject.GetComponent<AudioSource> ().Play ();
		}
	}
		
	// Call this to make the siren shut up
	public void StopAlarm()
	{
		// Stops the siren sound
		gameObject.GetComponent<AudioSource> ().Stop ();
	}
}