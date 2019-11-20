//NOTES: The character follows Erika now, but the animation doesn't work. I would like
//to be able to rescrict Amy to where she can't rotate as much, but we'll see how things work.

using UnityEngine;
using System.Collections;

public class FollowCode : MonoBehaviour 
{

	public Transform target; //the player
	public float speed = 1; //speed that the follower moves
	Vector3 targetUp; 
	Vector3 targetDown;
	Vector3 targetRight;
	Vector3 targetLeft;
	Vector3 closeTarget;
	GameObject[] playersArray;
	//Animator anim; //Animator for the animation of the follower

	// Use this for initialization
	void Start () 
	{
		playersArray = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CheckForCharacters>().allPlayers;
		//anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () 
	{

		//I want the follower to be behind the player at the maximum distance of .3, so I'll take targetDown, Left, Right, and Up and make them 
		//the target position for the follower whenever the Input keys are pressed, which i'll need to change a little so that when player stops
		//the follower will catch up and then stop 0.3 away from player again.

		targetUp = target.position + new Vector3(0, -0.3f, 0); //Player's position plus -0.3f on the y
		targetDown = target.position + new Vector3 (0, 0.3f, 0); //Player's position plus 0.3f on the y
		targetRight = target.position + new Vector3 (-0.3f, 0, 0); //Player's position plus -0.3f on the x
		targetLeft = target.position + new Vector3 (0.3f, 0, 0); // Player's position plus 0.3f on the x

		//When player moves, the follower will move behind the character, 0.3 away while following the Player.

		if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && transform.position.x > targetLeft.x)
		{
			transform.position = Vector3.MoveTowards(transform.position, targetLeft, speed * Time.deltaTime);
			//AnimationConfiguration();
		}
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			transform.position = Vector3.MoveTowards(transform.position, targetRight, speed * Time.deltaTime);
			//AnimationConfiguration();
		}
		if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			transform.position = Vector3.MoveTowards(transform.position, targetDown, speed * Time.deltaTime);
			//AnimationConfiguration();
		}
		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			transform.position = Vector3.MoveTowards(transform.position, targetUp, speed * Time.deltaTime);
			//	AnimationConfiguration();
		}
//			if((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && transform.position.x > targetLeft.x)
//		{
//			transform.position = Vector3.MoveTowards(transform.position, targetLeft, speed * Time.deltaTime);
//			//AnimationConfiguration();
//		}
//		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
//		{
//			transform.position = Vector3.MoveTowards(transform.position, targetRight, speed * Time.deltaTime);
//			//AnimationConfiguration();
//		}
//		if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
//		{
//			transform.position = Vector3.MoveTowards(transform.position, targetDown, speed * Time.deltaTime);
//			//AnimationConfiguration();
//		}
//		if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
//		{
//			transform.position = Vector3.MoveTowards(transform.position, targetUp, speed * Time.deltaTime);
//			//	AnimationConfiguration();
//		}
		//End of follower behind by 0.3 of Player code
		followCollider(); //Calls followCollider (the code needed to deactivate the collider so they don't push each other around)

	}

	void followCollider()
	{
		Vector3 rightTarget;
		Vector3 leftTarget;
		Vector3 upTarget;
		Vector3 downTarget;

		//Player's position x and y plus either 0.15 or -0.15
		rightTarget = target.position + new Vector3 (0.15f,0,0);
		leftTarget = target.position + new Vector3 (-0.15f,0,0);
		upTarget = target.position + new Vector3 (0,0.15f,0);
		downTarget = target.position + new Vector3(0,-0.15f,0);

		//Turns off box collider of the follower when they get close enough to the character
		if(transform.position.x < rightTarget.x || transform.position.x > leftTarget.x)
		{
			playersArray[1].GetComponent<BoxCollider2D>().enabled = false; //Turns off the Box collider
		}
		if(transform.position.y > downTarget.y || transform.position.y < upTarget.y)
		{
			playersArray[1].GetComponent<BoxCollider2D>().enabled = false;
		}

		//Turns the collider back on if the follower is so far away from the player. I used the variables from the follow code
		//to make sure that the follower's collider doesn't turn back on. This doesn't work correctly without them so I did something right. :3
		if(transform.position.y < downTarget.y && transform.position.y < targetDown.y)
		{
			playersArray[1].GetComponent<BoxCollider2D>().enabled = true; //Turns on the Box collider
		}
		if(transform.position.y > upTarget.y && transform.position.y > targetUp.y)
		{
			playersArray[1].GetComponent<BoxCollider2D>().enabled = true;
		}
		if(transform.position.x > rightTarget.x && transform.position.x > targetRight.x)
		{
			playersArray[1].GetComponent<BoxCollider2D>().enabled = true;
		}
		if(transform.position.x < leftTarget.x && transform.position.x < targetLeft.x)
		{
			playersArray[1].GetComponent<BoxCollider2D>().enabled = true;
		}

	}

//	void AnimationConfiguration() //Code to make the follow's animation work, this is unfinished and doesn't work.
//	{
//		float inputX;
//		float inputY;
//		Animator erikaAnim;
//
//		//erikaAnim = erika.GetComponent<Animator>();
//		inputX = transform.position.x;
//		inputY = transform.position.y;
//
//		anim.SetFloat("Input_X", inputX);
//		anim.SetFloat("Input_Y", inputY);
//
//	/*	if(erikaAnim.GetBool("IsIdle", true))
//		{
//			anim.SetBool("IsIdle", true);
//		}
//		if(erikaAnim.GetBool("IsWalking", true))
//		{
//			anim.SetBool("IsWalking", true);
//		}  */
//
//	}

}
