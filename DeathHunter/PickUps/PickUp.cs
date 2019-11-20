using UnityEngine;
using System.Collections;

public abstract class PickUp : MonoBehaviour
{
	private const float bobHeight = 0.25f;
	private const float bobSpeed = 1f;
	private const float spinSpeed = 45f;

	[SerializeField] private AudioSource pickupSound;

	private void Start()
	{
		pickupSound = GameObject.FindGameObjectWithTag ("PickSound").GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update ()
	{
		transform.Translate (Vector3.up * bobHeight * Mathf.Sin(Time.timeSinceLevelLoad * bobSpeed) * Time.deltaTime, Space.World);
		transform.Rotate (Vector3.up * spinSpeed * Time.deltaTime, Space.World);
	}

	private void OnTriggerEnter(Collider collider)
	{
		var player = collider.GetComponent<Player>();
		if (player)
		{
			pickupSound.Play ();
			PickThisUp (player);
			Destroy (gameObject);
		}
	}

	protected abstract void PickThisUp (Player player);
}