using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour {

	private static Singleton instance = null;
	public static Singleton Instance
	{
		get {return instance;}
	}
	// Use this for initialization
	void Awake () 
	{
		if(instance != null && instance != this)
		{
			Destroy (gameObject);
			return;
		}
		else
		{
			instance = this;
		}
		DontDestroyOnLoad(gameObject);
	}
}
