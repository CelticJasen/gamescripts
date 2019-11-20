using UnityEngine;
using System.Collections;

public class TestSaveData : MonoBehaviour
{
	private void Start()
	{
		SaveData newSaveData = new SaveData ();
		newSaveData.foo = "Hello Foo!";
		newSaveData.bar = 10;
		newSaveData.Save ("MySave");

		SaveData loadedSaveData = SaveData.Load ("My Save");
		Debug.LogFormat ("The loaded data has a value of {0} for foo, and a value of {1} for bar", loadedSaveData.foo, loadedSaveData.bar);
	}
}