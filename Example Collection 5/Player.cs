using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int Health = 4;
	public int fallBoundary = -20;
	public Texture2D heartTexture;

	void Update (){
		if (transform.position.y <= fallBoundary) {
			DamagePlayer (1);
			transform.position = new Vector3 (0f, 1.5f, 0f);
		}
	}

	void OnGUI (){
		if (Health == 4) {
			GUI.DrawTexture (new Rect (10, 10, 200, 60), heartTexture, ScaleMode.StretchToFill , true, 10.0f);
			GUI.DrawTexture (new Rect (60, 10, 200, 60), heartTexture, ScaleMode.StretchToFill, true, 10.0f);
			GUI.DrawTexture (new Rect (110, 10, 200, 60), heartTexture, ScaleMode.StretchToFill, true, 10.0f);
			GUI.DrawTexture (new Rect (160, 10, 200, 60), heartTexture, ScaleMode.StretchToFill, true, 10.0f);
		}
		if (Health == 3) {
			GUI.DrawTexture (new Rect (10, 10, 200, 60), heartTexture, ScaleMode.StretchToFill, true, 10.0f);
			GUI.DrawTexture (new Rect (60, 10, 200, 60), heartTexture, ScaleMode.StretchToFill, true, 10.0f);
			GUI.DrawTexture (new Rect (110, 10, 200, 60), heartTexture, ScaleMode.StretchToFill, true, 10.0f);
		}
		if (Health == 2) {
			GUI.DrawTexture (new Rect (10, 10, 200, 60), heartTexture, ScaleMode.StretchToFill, true, 10.0f);
			GUI.DrawTexture (new Rect (60, 10, 200, 60), heartTexture, ScaleMode.StretchToFill, true, 10.0f);
		}
		if (Health == 1) {
			GUI.DrawTexture (new Rect (10, 10, 200, 60), heartTexture, ScaleMode.StretchToFill, true, 10.0f);
		}
	}

	public void DamagePlayer (int damage) {
		Health -= damage;
		if (Health <= 0) {
			Application.LoadLevel("GameOver");
		}
	}
}