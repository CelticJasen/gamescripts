﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DestroyInstructionsOnLoad : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(SceneManager.GetActiveScene().name == "BarnScene")
		{
			Destroy(this);
		}
	}
}