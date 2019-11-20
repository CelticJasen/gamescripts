using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image credits;

	// Use this for initialization
	void Start ()
    {
		DontDestroyOnLoad (transform.gameObject);
        credits.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}