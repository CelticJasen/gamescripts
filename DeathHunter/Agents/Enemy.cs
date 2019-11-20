using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : Agent
{
	[Header("Enemy Settings")]
	[SerializeField] private Weapon defaultWeapon;

	[Header("Drops")]
	[SerializeField] private WeightedObject[] drops;

	private Transform target;
	private NavMeshAgent navMeshAgent;
	private Vector3 desiredVelocity;

	protected override void Awake()
	{
		base.Awake ();
		navMeshAgent = GetComponent<NavMeshAgent> ();

		if (defaultWeapon)
		{
			EquipWeapon (defaultWeapon);
		}

		// Events
		Health.events.onDie.AddListener(HandleOnDie);
	}

	private void Start()
	{
		Toolbox.UIManager.RegisterEnemy (this);
	}

	protected override void OnDieEnd()
	{
		if (drops.Length > 0)
		{
			var drop = WeightedObject.Select (drops);
			Instantiate (drop, transform.position + drop.transform.position, drop.transform.rotation);
			Toolbox.GameManager.EnemiesKilled ++;
		}

		base.OnDieEnd ();
	}

	protected override void HandleOnDie()
	{
		navMeshAgent.enabled = false;
		base.HandleOnDie ();
	}

	protected override void Update()
	{
		base.Update ();

		if (Toolbox.Player)
		{
			if (navMeshAgent.enabled)
			{
				navMeshAgent.Resume ();
				navMeshAgent.SetDestination (Toolbox.Player.transform.position);
			}

			if (EquippedWeapon)
			{
				if(EquippedWeapon.AIShouldAttack(Toolbox.Player.transform.position))
				{
					EquippedWeapon.StartAttack();
				}
				else
				{
					EquippedWeapon.EndAttack();
				}
			}
		}

		desiredVelocity = Vector3.MoveTowards (desiredVelocity, navMeshAgent.desiredVelocity, navMeshAgent.acceleration * Time.deltaTime);
		var input = transform.InverseTransformDirection (desiredVelocity);
		Animator.SetFloat ("Horizontal", input.x);
		Animator.SetFloat ("Vertical", input.z);
		Animator.speed = navMeshAgent.speed;
	}

	private void OnAnimatorMove()
	{
		navMeshAgent.velocity = Animator.velocity;
	}
}