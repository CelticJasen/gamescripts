using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainButtons : MonoBehaviour
{
	public StartCam scanButtonScript;

	public Button quitButton;
	public Button scanButton;
	public Button infoButton;
	public Text scanText;
	public int randomNumber;
	public int scannedTree;

	public void Start()
	{
		
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	public void QuitPress()
	{
		Application.Quit ();
	}

	public void InfoPress()
	{
//		scanButtonScript.OnDestroy();
//		StartCoroutine(HoldUp());
		if(scannedTree == 1)
		{
			SceneManager.LoadScene("PinOak");
		}

		if(scannedTree == 2)
		{
			SceneManager.LoadScene("DouglasFir");
		}

		if(scannedTree == 3)
		{
			SceneManager.LoadScene("RedMaple");
		}

		if(scannedTree == 4)
		{
			SceneManager.LoadScene("Hickory");
		}

		if(scannedTree == 5)
		{
			SceneManager.LoadScene("Manchineel");
		}
	}

	public void ScanPress()
	{
		randomNumber = Random.Range(1, 6);
		if(randomNumber == 1)
		{
			scanText.text = "You scanned pin oak!";
			scannedTree = 1;
		}

		if(randomNumber == 2)
		{
			scanText.text = "You scanned douglas fir!";
			scannedTree = 2;
		}

		if(randomNumber == 3)
		{
			scanText.text = "You scanned red maple!";
			scannedTree = 3;
		}

		if(randomNumber == 4)
		{
			scanText.text = "You scanned hickory!";
			scannedTree = 4;
		}

		if(randomNumber == 5)
		{
			scanText.text = "You scanned manchineel!";
			scannedTree = 5;
		}
	}

//	IEnumerator HoldUp()
//	{
//		yield return new WaitForSeconds(1);
//		SceneManager.LoadScene("AgricultureInfo");
//	}

//	public void ScanPress()
//	{
//		scanButtonScript.DecodeQR();
//	}
}