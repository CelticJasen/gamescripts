using UnityEngine;
using System.Collections;

public class MenuAddOn : MonoBehaviour 
{
	RectTransform startRect; 
	RectTransform quitRect;
	GameObject startSprite;
	GameObject quitSprite;

	// Use this for initialization
	void Start () 
	{
		startSprite = GameObject.FindGameObjectWithTag("startSprite");
		quitSprite = GameObject.FindGameObjectWithTag("quitSprite");
	}
	
	// Update is called once per frame
//	void Update () 
//	{
//		if(Input.mousePosition.x > 400 && Input.mousePosition.y > 15 && Input.mousePosition.x < 400+160 && Input.mousePosition.y<15+30)
//		{
//			Debug.Log("I'm over it!");
//			//show animated player next to button
//			startSprite.GetComponent<SpriteRenderer>().enabled = true;
//			quitSprite.GetComponent<SpriteRenderer>().enabled = false;
//
//
//		}
//		if(Input.mousePosition.x > 400 && Input.mousePosition.y > -316 && Input.mousePosition.x < 400+160 && Input.mousePosition.y < -316+30)
//		{
//			//show animated player next to button
//			startSprite.GetComponent<SpriteRenderer>().enabled = false;
//			quitSprite.GetComponent<SpriteRenderer>().enabled = true;
//		}
//	}

}
