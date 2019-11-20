using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTargetSceneButton : MonoBehaviour
{
	public void LoadSceneNum(int num)
	{
		if (num < 0 || num >= SceneManager.sceneCountInBuildSettings)
		{
			Debug.LogWarning ("Can't load scene " + num + ". It's beyond the scene count for this project. Did you add the scene to build settings?");
			return;
		}

		LoadingScreenManager.LoadScene (num);
	}
}