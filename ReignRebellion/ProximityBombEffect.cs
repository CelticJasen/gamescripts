using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityBombEffect : MonoBehaviour
{
	[SerializeField]
	private float effectRadius = 1;

	public float pbDam;
	public float pbHealth;
	public float pbRange;

	[Tooltip("The name tag of this player's team")]
	[SerializeField]
	private string myTeam;

    // Use this for initialization
    void Start ()
	{
		this.GetComponent<SphereCollider> ().radius = effectRadius;
		//Sets the sphere collider radius to the pbRange variable
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!other.GetComponent<Tags>().HasTag(myTeam) && other.GetComponent<Tags>().HasTag("Magical Being"))
		{
			other.GetComponent<PlayerManager>().currentHealth -= pbDam;
		}
	}
}