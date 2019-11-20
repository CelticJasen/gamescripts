using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
	Vector3 playerPosition;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Toolbox.Player)
		{
			// Camera position set to the same x and (z - 7) axis as the player
			playerPosition = Toolbox.Player.transform.position;
			gameObject.transform.position = new Vector3 (playerPosition.x, gameObject.transform.position.y, playerPosition.z - 10);
		}
	}
}