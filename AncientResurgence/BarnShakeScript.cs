using UnityEngine;
using System.Collections;

public class BarnShakeScript : MonoBehaviour
{
    public GameObject player;
    public GameObject myCamera;
    public float shakeDuration = 0.1f;
    public float elapsed = 0.0f;
    public float percentComplete = 0.0f;
    public Vector3 originalCamPos;
    public AudioSource quake;
	public bool isShaking;
	public bool hasShaken = false;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (isShaking == true)
		{
			player.GetComponent<Movement> ().canMove = false;
			player.GetComponent<Animator> ().SetBool ("IsWalking", false);
			player.GetComponent<Animator> ().SetBool ("IsRunning", false);
			player.GetComponent<Animator> ().SetBool ("IsIdle", true);
		}
		if (isShaking == false) 
		{
			player.GetComponent<Movement> ().canMove = true;
		}
	}

    void OnTriggerEnter2D(Collider2D Other)
    {
		if (hasShaken == false) 
		{
			if (Other.tag == "Player")
			{
				StartCoroutine(Shake());
				quake.Play();

			}
		} 
    }

    IEnumerator Shake()
    {
        float elapsed = 0.0f;


        Vector3 originalCamPos = myCamera.transform.position;

        while (elapsed < 1.0f)
        {
			
            elapsed += Time.deltaTime;
			isShaking = true;
            float percentComplete = elapsed / 1.0f;
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

		isShaking = false;
		hasShaken = true;
    }
}