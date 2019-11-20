using UnityEngine;
using System.Collections;

public class Camera2DFollowWithBounds : MonoBehaviour
{
	public float rightBound;
	public float leftBound;
	public float topBound;
	public float bottomBound;

	private Vector3 pos;
	public Transform target;

	// Use this for initialization
	void Start ()
	{
		leftBound = 121;
		rightBound = 679;
		bottomBound = -732;
		topBound = -68;
	}
	
	// Update is called once per frame
	void Update ()
	{
		pos = new Vector3(target.position.x, target.position.y, transform.position.z);
		pos.x = Mathf.Clamp(pos.x, leftBound, rightBound);
		pos.y = Mathf.Clamp(pos.y, bottomBound, topBound);
		transform.position = pos;
	}
}