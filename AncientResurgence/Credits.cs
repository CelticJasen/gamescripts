using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Credits : MonoBehaviour 
{
	public GameObject player;
	public GameObject gameManager;

    private GameObject blackFade;

	// Use this for initialization
	void Start () 
	{
		gameManager = GameObject.FindGameObjectWithTag ("GameManager");
        blackFade = GameObject.FindGameObjectWithTag("BlackFade");

        blackFade.GetComponent<FadeToBlack>().darkening = false;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void OnTriggerEnter2D (Collider2D Other)
	{
		if (Other.tag == "Player") 
		{
            SceneManager.LoadScene("Credits");
		}
	}
}