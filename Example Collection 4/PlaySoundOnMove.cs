using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
public class PlaySoundOnMove : MonoBehaviour
{
	private bool isPlaying = false;

	[SerializeField]
	[Tooltip("The audio source to play")]
	private AudioSource footstepSoundSource;
	[SerializeField]
	[Tooltip("This is to be a reference to the main parent object of the player character. It's tested for movement.")]
	private GameObject thePlayer;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Check if character is not standing still
		if (thePlayer.GetComponent<Rigidbody> ().velocity != Vector3.zero)
		{
			//Check if the audio source is already playing or not
			if (!isPlaying)
			{
				//The audio source will be played and the bool will be set to true so this script knows it's playing
				isPlaying = true;
				footstepSoundSource.Play ();
			}
		} 
		else if(isPlaying)
		{
			//If the character is standing still, stop the sound and set bool to false so this script knows the sound isn't playing
			isPlaying = false;
			footstepSoundSource.Stop ();
		}
	}
}