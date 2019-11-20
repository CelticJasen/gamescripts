using UnityEngine;
using System.Collections;

public class Cutscenes : MonoBehaviour 
{
	//The start position of the character
	Vector3[] Marker = new Vector3[6];
	//Vector3 startMarker2;
	//The end position for the cutscene
	//Vector3 endMarker;
	//Vector3 endMarker2;
	//Movement speed
	float[] speed = new float[5];
	//Time
	float[] startTime = new float[6];
	//float nextStartTime;
	//Total Distance
	float journeyLength;
	float nextJourney;
	//The variable that the character uses
	Animator anim;
	//The rigidbody of the character
	Rigidbody2D erikaBody;
	//bool so you can move after it reaches end position
	int placement = 1;
	int i = 1;
	float lerpAmount;

	// Use this for initialization
	void Start () 
	{
		startTime[1] = Time.time; //Noting the time the movement started
		//startMarker = new Vector3 (3f, -2f, 0); //the starting position
		anim = GetComponent<Animator> (); //Calling the animator on the player
		erikaBody = GetComponent<Rigidbody2D> (); //Calling the Rigidbody2D of the player

		//calculate journey length
		Marker [1] = new Vector3 (3f, -2f, 0);
		Marker [2] = new Vector3 (3f, -2.9f, 0);
		Marker [3] = new Vector3 (5.3f, -2.9f, 0);
		Marker [4] = new Vector3 (5.3f, -4f, 0);

		//nextJourney = Vector3.Distance (Marker[2], Marker[3]);

	}
	
	// Update is called once per frame
	void Update () 
	{
		journeyLength = Vector3.Distance (Marker[i], Marker[i + 1]); //calculating the total length of the journey
		float disCovered = (Time.time - startTime[i]) * speed[i];
		float fracJourney = disCovered / journeyLength; //calculates the halfway mark
//		var test = transform.position - transform.position;

		if (placement == 1) {
			speed[1] = 0.5f;
			animationConfiguration ();
			anim.SetBool ("IsWalking", true);
			transform.position = Vector3.Lerp (Marker [i], Marker [i+1], fracJourney);

			//MoveTowardsTarget ();
			if (transform.position.y == Marker [2].y) {
				placement = placement + 1;
				i = i + 1;
				print ("placement change");
				startTime[2] = Time.time;
				speed[2] = 0.5f;
				//anim.SetBool("IsWalking", true);

			}
		} else if (placement == 2) {
			//MoveTowardsTarget ();
			configurationAnimation ();
			anim.SetBool ("IsWalking", true);
			transform.position = Vector3.Lerp (Marker [i], Marker [i+1], fracJourney);
			if (transform.position == Marker [3]) {
				placement = placement + 1;
				print ("Again");
				startTime[3] = Time.time;
				i = i + 1;
				configurationAnimation();
				speed[3] = 0.5f;
			} 
		} 
		else if (placement == 3) 
		{
			animationConfiguration ();
			anim.SetBool("IsWalking", true);
			transform.position = Vector3.Lerp (Marker[i], Marker[i+1], fracJourney);
			if(transform.position == Marker[4])
			{
				placement = placement + 1;
				startTime[4] = Time.time;
				i = i + 1;
			}

		}
		else
		{
			anim.SetBool ("IsWalking", false);
			anim.SetBool("IsIdle", true);
		}
		if (placement == 4) 
		{
			anim.SetBool ("IsIdle", true);
			animationConfiguration ();
		}
		else 
		{
			anim.SetBool("IsIdle", false);
		}
	}

	void MoveTowardsTarget ()
	{
		Marker [1] = new Vector3 (3f, -2f, 0);
		Marker [2] = new Vector3 (3f, -3f, 0);
		Marker [3] = new Vector3 (4f, -3f, 0); 

	}

	void animationConfiguration ()
	{
		//Code used for the Input_X and Input_Y in the animation 
		Vector2 yInput;
		Vector2 xInput;
		yInput = erikaBody.position + new Vector2 (0, -5);
		xInput = erikaBody.position + new Vector2 (-5, 0); 
		anim.SetFloat("Input_X", xInput.x);
		anim.SetFloat("Input_Y", yInput.y);
	}
	void configurationAnimation ()
	{
		Vector2 yInput;
		Vector2 xInput;
		yInput = erikaBody.position + new Vector2 (0, 5);
		xInput = erikaBody.position + new Vector2 (5, 0);
		anim.SetFloat ("Input_X", xInput.x);
		anim.SetFloat ("Input_Y", yInput.y);
	}

}