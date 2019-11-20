using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBombEffect : MonoBehaviour
{
	[Header("Ability Values")]
	[Tooltip("How much force is used to push enemy players away")]
	[SerializeField]
	private float repelForce = 0;
	[Tooltip("How long the shield will persist")]
	[SerializeField]
	private float lifetime = 0;
	[Tooltip("The radius of the shield effect")]
	[SerializeField]
	private float effectRadius = 1;
	[Tooltip("The name tag of this player's team")]
	[SerializeField]
	public string myTeam;

	private float timer = 0;

    // Use this for initialization
    void Start ()
	{
		this.GetComponent<SphereCollider> ().radius = effectRadius;
		//Sets the sphere collider radius to the effectRadius variable
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;

		if (timer > lifetime)
		{
			Destroy (gameObject);
		}
	}

	private void OnTriggerStay(Collider other)
	{
		//If the triggerer of this has the script tag of the opposite team and magic being it should repel them in the opposite direction of the collider
		if(!other.GetComponent<Tags>().HasTag(myTeam) && other.GetComponent<Tags>().HasTag("Magic Being"))
		{
			Vector3 forceDirection = gameObject.transform.position - other.gameObject.transform.position;

			other.gameObject.GetComponent<Rigidbody>().AddForce(-forceDirection * repelForce);
		}
	}

	//Destroys a projectile if it touches this thing's collider
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Projectile") //TODO: Change this logic to something that will detect if the projectile is from an enemy
		{
			Destroy (other);
		}
	}
}