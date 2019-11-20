using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerLoadLevel : MonoBehaviour
{
	public string Level;
	public Vector3 targetPosition;
	public Vector3 targetCameraPosition;
	public GameObject myCamera;
	public GameObject player;
	public BoxCollider2D Bounds;
	private GameObject boundaries;
    public Image blackFade;
    public GameObject blackness;
    public GameObject gameManager;

	// Use this for initialization
	void Start () 
	{
		myCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		player = GameObject.FindGameObjectWithTag ("Player");
		boundaries = GameObject.FindGameObjectWithTag ("Boundaries");
		Bounds = boundaries.GetComponent<BoxCollider2D>();
        blackFade = GameObject.FindGameObjectWithTag("BlackFade").GetComponent<Image>();
        blackness = GameObject.FindGameObjectWithTag("BlackFade");
    }
	
	// Update is called once per frame
	void Update () 
	{

	}

    void OnLevelWasLoaded()
    {
        myCamera = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
        boundaries = GameObject.FindGameObjectWithTag("Boundaries");
        Bounds = boundaries.GetComponent<BoxCollider2D>();
        blackFade = GameObject.FindGameObjectWithTag("BlackFade").GetComponent<Image>();
        blackness = GameObject.FindGameObjectWithTag("BlackFade");

        blackness.GetComponent<FadeToBlack>().darkening = false;

        if (SceneManager.GetActiveScene().name == "InsideBarn")
        {
            targetPosition = new Vector3(0.95f, -2.0f, 0.0f);
            targetCameraPosition = new Vector3(0.95f, -2.0f, 0.0f);
            Level = "DemoTunnel";
        }

        if(SceneManager.GetActiveScene().name == "DemoTunnel")
        {
            this.GetComponent<CheckForCharacters>().FindPlayers();
			Level = "Credits";
        }
    }

	void OnTriggerEnter2D (Collider2D Other)
	{
		if (Other.tag == "Player") 
		{
            StartCoroutine(StartFade());
		}
	}

    public void Trigger()
    {
        //myCamera.gameObject.GetComponent<Camera>().farClipPlane = 5;
        //boundaries.SetActive(false);
        //player.transform.position = targetPosition;
        //myCamera.transform.position = targetCameraPosition;
        SceneManager.LoadScene(Level);
        //this.GetComponent<CheckForCharacters>().FindPlayers();
    }

    IEnumerator StartFade()
    {
        blackFade.GetComponent<FadeToBlack>().darkening = true;
        yield return new WaitForSeconds(2.0f);
        myCamera.gameObject.GetComponent<Camera>().farClipPlane = 5;
        boundaries.SetActive(false);
        player.transform.position = targetPosition;
        myCamera.transform.position = targetCameraPosition;
//        gameManager.GetComponent<FadeBackInAfterLoadingLevel>().tempLevelUse = "Null";
        SceneManager.LoadScene(Level);
    }
}