using UnityEngine;
using System.Collections;

public class MeleeWeapon : Weapon
{
	[SerializeField] private bool attacking = false;
	[SerializeField] private float attackDuration;
	[SerializeField] private bool attacked = false;
	[SerializeField] private float attackTimerDuration;
	[SerializeField] private AudioSource sliceSound;

	private float attackDurationTimer;
	private float attackTimer;

	private void Start()
	{
		sliceSound = GameObject.FindGameObjectWithTag ("SliceSound").GetComponent<AudioSource> ();
	}

	private void Update()
	{
		if (attacking)
		{
			attackDurationTimer += Time.deltaTime;
		}

		if (attackDurationTimer > attackDuration)
		{
			attacking = false;
			attackDurationTimer = 0;
		}

		if (attacked)
		{
			attackTimer += Time.deltaTime;
		}

		if (attackTimer > attackTimerDuration)
		{
			attacked = false;
			attackTimer = 0;
		}
	}

	private void OnTriggerEnter(Collider collision)
	{
		var health = collision.transform.GetComponent<Health> ();
		if (health && attacking)
		{
			sliceSound.Play ();
			health.Modify (-damage);
		}
	}

	#region implemented abstract members of Weapon

	public override void StartAttack ()
	{
		if (gameObject.GetComponentInParent<Animator> ().GetCurrentAnimatorStateInfo(0).fullPathHash != Animator.StringToHash("Attack") && !attacked)
		{
			gameObject.GetComponentInParent<Animator> ().SetTrigger ("Attack");
			attacking = true;
			attacked = true;
		}
	}

	public override void EndAttack ()
	{
		return;
	}

	public override bool AIShouldAttack(Vector3 target)
	{
		var weaponToTarget = target - gameObject.transform.position;
		if (weaponToTarget.sqrMagnitude > Mathf.Pow(aiAttackRange, 2f))
		{
			return false;
		}

		return Vector3.Angle (gameObject.transform.forward, weaponToTarget) < aiAttackAngle;
	}

	#endregion
}