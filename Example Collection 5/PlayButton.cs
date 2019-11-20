using UnityEngine;
using System.Collections;

public class PlayButton : MonoBehaviour {

	public Texture btnTexture;
	void OnGUI(){
		if (!btnTexture) {
			Debug.LogError ("Please assign a texture on the inspector");
		}
		if (GUI.Button (new Rect(300, 300, 200, 140), btnTexture))
			Application.LoadLevel("Platformy");
	}
}