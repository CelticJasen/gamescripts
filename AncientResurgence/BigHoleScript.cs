using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BigHoleScript : MonoBehaviour
{
    public GameObject player;
    public GameObject myCamera;
    public float shakeDuration = 0.1f;
    public float elapsed = 0.0f;
    public float percentComplete = 0.0f;
    public Vector3 originalCamPos;
	private Animator playerAnim;
    public GameObject gameManager;
	public AudioClip scream;
	public AudioSource source;

    public AudioSource quake;

    public Image blackFade;
    public GameObject blackness;

    public GameObject bigHole;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myCamera = GameObject.FindGameObjectWithTag("MainCamera");
        playerAnim = player.GetComponent<Animator> ();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
		source = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource> ();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnLevelWasLoaded()
    {
        blackFade = GameObject.FindGameObjectWithTag("BlackFade").GetComponent<Image>();
        blackness = GameObject.FindGameObjectWithTag("BlackFade");

        blackness.GetComponent<FadeToBlack>().darkening = false;
    }

    void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.tag == "Player")
        {
            StartCoroutine(Shake());
            StartCoroutine(FadeFall());

            bigHole.GetComponent<SpriteRenderer>().sortingOrder = 1;

            blackness.GetComponent<FadeToBlack>().darkening = true;

            playerAnim.Play ("Falling");
			source.Play();
            quake.Play();
			playerAnim.SetBool ("IsIdle", false);
			playerAnim.SetBool ("IsWalking", false);
			player.GetComponent<Movement> ().enabled = false;
        }
    }

    IEnumerator Shake()
    {

        float elapsed = 0.0f;

        Vector3 originalCamPos = myCamera.transform.position;

        while (elapsed < 0.2f)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / 0.2f;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= 0.1f * damper;
            y *= 0.1f * damper;

            x = x + originalCamPos.x;
            y = y + originalCamPos.y;

            myCamera.transform.position = new Vector3(x, y, originalCamPos.z);

            yield return null;
        }
        
        myCamera.transform.position = originalCamPos;
    }

    IEnumerator FadeFall()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("DemoTunnel");
    }
}