using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SightScript : MonoBehaviour
{
	// Declare variables here
	public float fieldOfView = 60.0f;
	public GameObject target;
	private GameObject gameController;

	private Light thisLight;
	private float viewPercentage;
	private float lightPercentage;

	Scene currentScene;

	// Use this for initialization
	void Start ()
	{
		// Gets a reference to the GameController game object
		gameController = GameObject.FindGameObjectWithTag ("GameController");
		// Gets a reference to the light component on this object
		thisLight = gameObject.GetComponent<Light> ();
		target = GameObject.FindGameObjectWithTag ("Player");
		currentScene = SceneManager.GetActiveScene ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		// If the CanSee bool is true
		if (CanSee(target) == true && currentScene.name == "LevelOne")
		{
			// Calls the RespawnButton function on the GameController
			gameController.GetComponent<GameController> ().RespawnButton();
			// Calls the SoundAlarms function on the GameController
			gameController.GetComponent<GameController> ().SoundAlarms();
		}

		if (CanSee(target) == true && currentScene.name == "LevelTwo")
		{
			// Calls the RespawnButton function on the GameController
			gameController.GetComponent<GameControllerLVLTwo> ().RespawnButton();
			// Calls the SoundAlarms function on the GameController
			gameController.GetComponent<GameControllerLVLTwo> ().SoundAlarms();
		}

		// Sets the viewPercentage variable to percentage of the fieldOfView percentage compared to 15
		viewPercentage = fieldOfView / 15;
		// Sets the spot angle of this light to a percentage based on the percentage of the field of view
		thisLight.spotAngle = 30 * viewPercentage;
	}

	// Call this to decide whether or not CanSee is true
	public bool CanSee ( GameObject target )
	{
		// We use the location of our target in a number of calculations - store it in a variable for easy access.
		Vector3 targetPosition = target.transform.position;

		// Find the vector from the agent to the target
		// We do this by subtracting "destination minus origin", so that "origin plus vector equals destination."
		Vector3 agentToTargetVector = targetPosition - transform.position;

		// Find the angle between the direction our agent is facing (forward in local space) and the vector to the target.
		float angleToTarget = Vector3.Angle (agentToTargetVector, transform.forward);

		// if that angle is less than our field of view
		if ( angleToTarget < fieldOfView )
		{
			// Create a variable to hold a ray from our position to the target
			Ray rayToTarget = new Ray();

			// Set the origin of the ray to our position, and the direction to the vector to the target
			rayToTarget.origin = transform.position;
			rayToTarget.direction = agentToTargetVector;

			// Create a variable to hold information about anything the ray collides with
			RaycastHit hitInfo;

			// Cast our ray for infinity in the direciton of our ray.
			//    -- If we hit something...
			if (Physics.Raycast (rayToTarget, out hitInfo, Mathf.Infinity))
			{
				// ... and that something is our target 
				if (hitInfo.collider.gameObject == target)
				{
					// return true 
					//    -- note that this will exit out of the function, so anything after this functions like an else
					return true;
				}
			}
		}
		// return false
		//   -- note that because we returned true when we determined we could see the target, 
		//      this will only run if we hit nothing or if we hit something that is not our target.
		return false; 
	}
}