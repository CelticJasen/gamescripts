using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DarkenAfterTime : MonoBehaviour
{
	public SpriteRenderer darkness;

	[Range(0,.003f)]
	public float alphaAmount;

	// Use this for initialization
	void Start ()
	{
		darkness = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (darkness.color.a < .75f)
		{
			darkness.color += new Color(1, 1, 1, alphaAmount);
		}
	}
}