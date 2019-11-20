using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreditsManager : MonoBehaviour
{
    public Image credits;

	// Use this for initialization
	void Start ()
    {
        credits = GameObject.FindGameObjectWithTag("Credits").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(credits.enabled == false)
        {
            credits.enabled = true;
        }
	}
}