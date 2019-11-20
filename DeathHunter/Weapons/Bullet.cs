using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Lifespan))]
public class Bullet : MonoBehaviour
{
	private float damage;

	private AudioSource bulletHitSound;

	private void Start()
	{
		bulletHitSound = GameObject.FindGameObjectWithTag ("BulletHitSound").GetComponent<AudioSource> ();
	}

	/// <summary>
	/// Sets the damage for the projectile.
	/// </summary>
	/// <param name="damage">Damage dealt on collision with a Health object. Use a positive number to deal damage.</param>

	public void SetDamage(float damage)
	{
		this.damage = damage;
	}

	private void OnCollisionEnter(Collision collision)
	{
		var health = collision.transform.GetComponent<Health> ();
		if (health)
		{
			bulletHitSound.Play ();
			health.Modify (-damage);
		}
		Destroy (gameObject);
	}
}