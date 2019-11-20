using UnityEngine;
using System.Collections;

public class Camera2DSmoothFollow : MonoBehaviour
{
	GameObject[] playersArray;
	public Transform currentTarget;

	public Vector2
		Margin,
		Smoothing;

	public BoxCollider2D Bounds;

	private GameObject boundaries;

	public Vector3
		_min,
		_max;

	public bool IsFollowing { get; set; }

	// Use this for initialization
	void Start ()
	{
		IsFollowing = true;
		playersArray = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CheckForCharacters>().allPlayers;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
        //if (playersArray[1] != null) // YOU MIGHT NEED TO DO THIS FOR EVERY SINGLE CHARACTER THINGY WHATEVER CUZ THIS FIXES THE NULL REFERENCE PROBLEM WE BEEN HAVIN
		foreach(GameObject player in playersArray)
		{
			if (player != null)
			{
				if(player.GetComponent<Movement>().enabled == true)
				{
					currentTarget = player.transform;
				}
			}
		}

        if(currentTarget == null)
        {
            currentTarget = GameObject.FindGameObjectWithTag("Player").transform;
        }

		if (GameObject.FindGameObjectWithTag ("Boundaries") != null)
		{
			boundaries = GameObject.FindGameObjectWithTag ("Boundaries");


			Bounds = boundaries.GetComponent<BoxCollider2D>();
			


			_min = Bounds.bounds.min;
			_max = Bounds.bounds.max;

			var x = transform.position.x;
			var y = transform.position.y;

			if (IsFollowing)
			{
				if (Mathf.Abs (x - currentTarget.position.x) > Margin.x)
					x = Mathf.Lerp (x, currentTarget.position.x, Smoothing.x * Time.deltaTime);

				if (Mathf.Abs (y - currentTarget.position.y) > Margin.y)
					y = Mathf.Lerp (y, currentTarget.position.y, Smoothing.y * Time.deltaTime);
			}

			var cameraHalfwidth = GetComponent<Camera>().orthographicSize * ((float)Screen.width / Screen.height);

			x = Mathf.Clamp (x, _min.x + cameraHalfwidth, _max.x - cameraHalfwidth);
			y = Mathf.Clamp (y, _min.y + GetComponent<Camera>().orthographicSize, _max.y - GetComponent<Camera>().orthographicSize);

			transform.position = new Vector3 (x, y, transform.position.z);
		}
	}
}