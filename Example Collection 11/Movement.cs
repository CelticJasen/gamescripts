using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
	
	//Declare Variables
	public Rigidbody2D rogueBody;
	Animator anim;
	float speed = 100f;
	public bool isDead = false;
	public bool isRight;
	public GameObject projectileDagger;
	public float fireRate = 0.2f;
	private float canFireIn;
	public int rogueHealth = 10;
	public bool inBounds = true;
	public float invisCoolDown = 20f;
	private float invisTimer;
	public Image invisIndicator;
	private AudioSource audioSource;
	public AudioClip invisReady;
	public AudioClip invisUse;
	public bool invis = false;
	private SpriteRenderer sRenderer;
	public Image healthBar;
	
	// Use this for initialization
	void Start () 
	{
		//Calls to the components from the scene
		rogueBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		audioSource = GameObject.FindGameObjectWithTag("GameController").GetComponent<AudioSource>();
		sRenderer = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		canFireIn -= Time.deltaTime;
		invisTimer -= Time.deltaTime;

		HandleInput();

		healthBar.rectTransform.sizeDelta = new Vector2(rogueHealth * 2 * 10, 25);

		if (rogueHealth < 1)
		{
			SceneManager.LoadScene("Menu");
		}

		if (invisTimer > 0)
		{
			invisIndicator.enabled = false;
		}
		else
		{
			invisIndicator.enabled = true;
		}

		if (invisTimer < 0 && invisTimer > -0.05f)
		{
			audioSource.PlayOneShot(invisReady);
		}

		if (invisTimer == 20)
		{
			audioSource.PlayOneShot(invisUse);
		}
	}

	public void HandleInput()
	{
		if (Input.GetMouseButton(0))
		{
			FireProjectile();
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Invisibility();
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene("Menu");
		}

		//Assigns horizontal and vertical stuffs to one vertex variable
		Vector2 movement_vector = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		Time.maximumDeltaTime = 0.03f;

		//Animation code stuff
		if (movement_vector != Vector2.zero) 
		{
			anim.SetBool ("IsWalking", true);
			anim.SetFloat("Input_X", movement_vector.x);
			anim.SetFloat("Input_Y", movement_vector.y);
		} 
		else 
		{
			anim.SetBool("IsWalking", false);
		}
				
		if (movement_vector == Vector2.zero)
		{
			anim.SetBool ("IsIdle", true);
		}
		else
		{
			anim.SetBool ("IsIdle", false);
		}

		//Flips the animation when going left
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			isRight = false;
			Flip();
		}
		if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			isRight = true;
			Flip();
		}

		//movement code uses both WASD and UP DOWN LEFT RIGHT keys (I believe by default)
		rogueBody.position += movement_vector * speed * Time.smoothDeltaTime;
	}

	void Flip()
	{
		if(isRight == false)
		{
			transform.eulerAngles = new Vector3(0,180,0);
		}
		else
		{
			transform.eulerAngles = new Vector3(0,0,0);
		}
		if(isRight == true)
		{
			transform.eulerAngles = new Vector3(0,0,0);
		}

	}

	public void FireProjectile()
	{
		if (canFireIn > 0)
		{
			return;
		}

		Instantiate(projectileDagger, rogueBody.position, Quaternion.Euler(0, 0, 0));
		canFireIn = fireRate;
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.tag == "GameController")
		{
			inBounds = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "GameController")
		{
			inBounds = false;
		}
	}

	void Invisibility()
	{
		if (invisTimer > 0)
		{
			return;
		}

		sRenderer.color = new Color(1f, 1f, 1f, 0.25f);
		invis = true;
		invisTimer = invisCoolDown;
		StartCoroutine(InvisTime());
	}

	IEnumerator InvisTime()
	{
		yield return new WaitForSeconds(5);
		sRenderer.color = new Color(1f, 1f, 1f, 1f);
		invis = false;
	}
}