using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LightningFlash : MonoBehaviour
{
	private bool raining = false;

	float beginLightning = 7.0f;
	float beginRain = 5.0f;
	float enteredTime = 0.0f;
	float minTime = 0.1f;
	float threshold = 0.95f;

	float minTimeLightning = 0.7f;
	float lightningThreshold = 0.9f;
	private float lastTimeLightning = 0.0f;


	public AudioClip thunder;

	public AudioSource rainSource;
	private AudioSource source;

	private float lastTime = 0.0f;
	public SpriteRenderer lightning;

	private NPCDialog textDialogue;

	void Awake ()
	{
		source = GetComponent<AudioSource>();
	}

	// Use this for initialization
	void Start ()
	{
		enteredTime = Time.time;

		textDialogue = GameObject.FindGameObjectWithTag("Dialog").GetComponent<NPCDialog>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (((Time.time - enteredTime) > beginRain) && raining == false)
		{
			rainSource.Play ();
			raining = true;

			textDialogue.BarnSceneWasJustLoaded();
			textDialogue.ActivateTextBox();
			textDialogue.StartTyping();
		}

		if ((Time.time - enteredTime) > beginLightning)
		{
			if ((Time.time - lastTime) > minTime)
			{
				if (Random.value > threshold)
				{
					lightning.color = new Color(1, 1, 1, 0.50f);
				}
				else
				{
					lightning.color = new Color(1, 1, 1, 0);
				}

				lastTime = Time.time;
			}

			if ((Time.time - lastTimeLightning) > minTimeLightning)
			{
				if (Random.value > lightningThreshold)
				{
					source.PlayOneShot(thunder, 1F);
				}

				lastTimeLightning = Time.time;
			}
		}
	}
}