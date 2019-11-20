using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityRaycast : MonoBehaviour
{
	[Tooltip("The angle of the detection ray.")]
	[SerializeField]
	private float fieldOfView = 60.0f;
	[SerializeField]
    [HideInInspector]
	public float rangeOfLifeForce = 1.0f;

	public bool CanSee (GameObject target)
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

			// Cast our ray for rangeOfLifeForce in the direciton of our ray.
			//    -- If we hit something...
			if (Physics.Raycast (rayToTarget, out hitInfo, rangeOfLifeForce))
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