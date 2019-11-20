using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Health))]
[RequireComponent(typeof(MeshRenderer))]
public class Target : MonoBehaviour
{
	private Health health;

	public Health Health { get { return health; } }

	private bool isDead = false;

	[SerializeField] private float deathTimer = 0;

	private void Awake()
	{
		health = gameObject.GetComponent<Health> ();
	}

	public void Update()
	{
		if (isDead == true)
		{
			deathTimer += Time.deltaTime;
		}

		if (deathTimer > 10)
		{
			Revive ();
		}
	}

	public void DeadTarget()
	{
		isDead = true;
		gameObject.GetComponent<MeshRenderer> ().enabled = false;
		gameObject.GetComponent<CapsuleCollider> ().enabled = false;
	}

	public void Revive()
	{
		health.Modify (Mathf.Infinity);
		isDead = false;
		deathTimer = 0;
		gameObject.GetComponent<MeshRenderer> ().enabled = true;
		gameObject.GetComponent<CapsuleCollider> ().enabled = true;
	}
}