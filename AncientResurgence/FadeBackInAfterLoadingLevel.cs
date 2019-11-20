using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeBackInAfterLoadingLevel : MonoBehaviour
{
    public Image blackFade;
    public string tempLevelUse;

	// Use this for initialization
	void Start ()
    {
        tempLevelUse = SceneManager.GetActiveScene().name;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(SceneManager.GetActiveScene().name != tempLevelUse)
        {
            blackFade.GetComponent<FadeToBlack>().darkening = false;
            tempLevelUse = SceneManager.GetActiveScene().name;
        }
	}
}