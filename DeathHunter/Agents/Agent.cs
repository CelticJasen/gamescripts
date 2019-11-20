using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Health))]
public class Agent : MonoBehaviour
{
	[Header("Projectile weapon settings")]
	[SerializeField] private Transform projectileWeaponContainer;
	[SerializeField] private float projectileWeaponAimSpeed;

	[Header("Melee weapon settings")]
	[SerializeField] private Transform meleeWeaponContainer;

	[Header("Death settings")]
	[SerializeField] private float despawnDelay = 3f;

	private Animator animator;
	private Health health;
	private Weapon equippedWeapon;

	public Animator Animator { get { return animator; } }
	public Weapon EquippedWeapon { get { return equippedWeapon; } }
	public Health Health { get { return health; } }

	protected virtual void Awake()
	{
		animator = GetComponent<Animator> ();
		health = GetComponent<Health> ();
	}

	protected virtual void HandleOnDie()
	{
		UnequipWeapon ();
		Invoke ("OnDieEnd", despawnDelay);
	}

	protected virtual void OnDieEnd()
	{
		Destroy (gameObject);
	}

	protected virtual void Update()
	{
		projectileWeaponContainer.rotation = Quaternion.Slerp (projectileWeaponContainer.rotation, transform.rotation, projectileWeaponAimSpeed * Time.deltaTime);
	}

	private void OnAnimatorIK()
	{
		if (equippedWeapon)
		{
			if (equippedWeapon is ProjectileWeapon)
			{
				var projectileWeapon = equippedWeapon as ProjectileWeapon;

				// Right hand
				animator.SetIKPosition (AvatarIKGoal.RightHand, projectileWeapon.RightHandIKTarget.position);
				animator.SetIKPositionWeight (AvatarIKGoal.RightHand, 1f);
				animator.SetIKRotation (AvatarIKGoal.RightHand, projectileWeapon.RightHandIKTarget.rotation);
				animator.SetIKRotationWeight (AvatarIKGoal.RightHand, 1f);

				// Right elbow
				animator.SetIKHintPosition (AvatarIKHint.RightElbow, projectileWeapon.RightElbowIKHint.position);
				animator.SetIKHintPositionWeight (AvatarIKHint.RightElbow, 1f);

				// Left hand
				animator.SetIKPosition (AvatarIKGoal.LeftHand, projectileWeapon.LeftHandIKTarget.position);
				animator.SetIKPositionWeight (AvatarIKGoal.LeftHand, 1f);
				animator.SetIKRotation (AvatarIKGoal.LeftHand, projectileWeapon.LeftHandIKTarget.rotation);
				animator.SetIKRotationWeight (AvatarIKGoal.LeftHand, 1f);

				// Left elbow
				animator.SetIKHintPosition (AvatarIKHint.LeftElbow, projectileWeapon.LeftElbowIKHint.position);
				animator.SetIKHintPositionWeight (AvatarIKHint.LeftElbow, 1f);
			}
		}
	}

	public void UnequipWeapon()
	{
		if (equippedWeapon)
		{
			Destroy (equippedWeapon.gameObject);
		}
		animator.SetInteger ("WeaponType", (int)Weapon.Animation.None);
	}

	public void EquipWeapon(Weapon weapon)
	{
		UnequipWeapon ();
		// Ternary Operator (Statement ? If True : If False)
		equippedWeapon = Instantiate (weapon, (weapon is ProjectileWeapon ? projectileWeaponContainer : meleeWeaponContainer), false) as Weapon;
		equippedWeapon.gameObject.layer = gameObject.layer;
		animator.SetInteger ("WeaponType", (int)equippedWeapon.AnimationType);
	}
}