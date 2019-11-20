using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
	
	//Declare Variables
	Rigidbody2D claireBody;
	Animator anim;
	float speed = 1f;
	public bool isClimbing;
	public bool isRunning;
	public bool canMove;
	public BoxCollider2D Bounds; // Holds a reference to a box collider to be used as a boundary. Assign this in the inspector
	private GameObject boundaries;
	public Vector3
		_min,
		_max;  // Holds a reference to the min and max values of the boundary that the Player cannot cross. This can be manipulated in the inspector but is automatically assigned when the Bounds variable is assigned
	public Inventory inventory; // Holds a reference to the inventory. Assign this in the inspector
	
	public float health = 100f; // The actual health of the Player. Be sure this is set to the same as maxHealth variable in the inspector
	public float hunger = 1200f; // The actual hunger of the Player. I chose this value because 1200 seconds is 20 minutes and this variable is reliant on time. Be sure this is set to the same as maxHunger variable in the inspector.
	
	//private int maxHealth = 100; // This just holds the max health for some math stuff
	private int maxHunger = 1200; // This just holds the max hunger for some math stuff
	
	public Image hungerMeter;  // Holds a reference to the hunger meter image. Assign this in the inspector
	private int hungerMeterOriginalSize = 145; // Holds the original width of the hunger meter image for some math stuff
	private float hungerPercentage; // Holds the percentage of hunger compared to maxHunger
	private float hungerMeterCurrentSize; // Holds the current width of the hunger meter set to the same percentage as hunger to maxHunger
	
	
	// Use this for initialization
	void Start () 
	{
		//Calls to the components from the scene
		claireBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
        hungerMeter = GameObject.FindGameObjectWithTag("HungerMeter").GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () 
	{
		
		hungerPercentage = hunger / maxHunger; //Gets the percentage of hunger to maxHunger
		hungerMeterCurrentSize = hungerPercentage * hungerMeterOriginalSize; //Sets the hunger meter to the same percentage as hunger to maxHunger
		
		hungerMeter.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, hungerMeterCurrentSize); //Changes the width of the hunger meter image to the hungerMeterCurrentSize variable
		
		if (hunger > 0)
		{
			hunger -= Time.deltaTime; //Constantly decreases hunger until it hits zero
		}

		


		if (GameObject.FindGameObjectWithTag ("Boundaries") != null)
		{
			boundaries = GameObject.FindGameObjectWithTag ("Boundaries");

			Bounds = boundaries.GetComponent<BoxCollider2D>();
			
			_min = Bounds.bounds.min;
			_max = Bounds.bounds.max;

			var x = transform.position.x;
			var y = transform.position.y;

			x = Mathf.Clamp (x, _min.x, _max.x - 0.13f);
			y = Mathf.Clamp (y, _min.y + 0.28f, _max.y);

			transform.position = new Vector3 (x, y, transform.position.z);
		}
		

		
		//Assigns horizontal and vertical stuffs to one vertex variable
		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		Time.maximumDeltaTime = 0.03f;
        //Animation code stuff
		if(canMove == true)
		{
	        if (Input.GetKey(KeyCode.LeftShift))
	        {
	            isRunning = true;
	        }
	        else if (Input.GetKey(KeyCode.Backslash))
	        {
	            speed = 0.5f;
	            isRunning = false;
	        }
	        else
	        {
	            speed = 1f;
	            isRunning = false;
	        }

			if (movement_vector != Vector2.zero && isClimbing == false && isRunning == true)		
			{
	            speed = 1.5f;
	            anim.SetBool("IsRunning", true);
	            anim.SetBool("IsWalking", false);
	            anim.SetBool("IsIdle", false);
	            anim.SetFloat("Input_X", movement_vector.x);
	            anim.SetFloat("Input_Y", movement_vector.y);
	        }
			else
			{
	            anim.SetBool("IsRunning", false);
			}

	        if (movement_vector != Vector2.zero && isClimbing == false && isRunning == false)
	        {
	            anim.SetBool("IsWalking", true);
	            anim.SetFloat("Input_X", movement_vector.x);
	            anim.SetFloat("Input_Y", movement_vector.y);

	        }
	        else
	        {
	            anim.SetBool("IsWalking", false);
	        }

			if (movement_vector == Vector2.zero && isClimbing == false)
			{
				anim.SetBool ("IsIdle", true);
			}
			else
			{
				anim.SetBool ("IsIdle", false);
			}
			
			if (isClimbing == true && movement_vector != Vector2.zero)
			{
				anim.SetBool ("IsClimbing", true);
				anim.SetFloat("Input_X", movement_vector.x);
				anim.SetFloat("Input_Y", movement_vector.y);
			}
			else
			{
				anim.SetBool("IsClimbing", false);
			}
			
			if (isClimbing == true && movement_vector == Vector2.zero)
			{
				anim.SetBool ("IsClimbingIdle", true);
			}
			else
			{
				anim.SetBool("IsClimbingIdle", false);
			}


		
		//movement code uses both WASD and UP DOWN LEFT RIGHT keys (I believe by default)

			claireBody.position += movement_vector * speed * Time.smoothDeltaTime;
		}
	}
	
	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Item")
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				inventory.AddItem(other.GetComponent<Item>());
				Destroy(other.gameObject);
			}
		}
	}
}