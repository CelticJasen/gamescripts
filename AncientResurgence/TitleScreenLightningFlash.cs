using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleScreenLightningFlash : MonoBehaviour
{
	public Image lightningImage;

	public AudioSource[] sources = new AudioSource[3]; //An array for the three Audio Sources in scene

	private float lastLightningFlash = 0.0f;
	private float threshold = 0.995f;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
    void Update ()
	{
		if(Random.value > threshold)
		{
            StartCoroutine(LightningTurnOffTime());
			sources[Random.Range(0, sources.Length)].Play(); //Chooses the audio source randomly and plays the clip on the audio source.
		}
	}

    IEnumerator LightningTurnOffTime()
    {
        lightningImage.color = new Color(0, 0, 0, 0);
        yield return new WaitForSeconds(0.0005f);
        lightningImage.color = new Color(0, 0, 0, 1);
    }
}