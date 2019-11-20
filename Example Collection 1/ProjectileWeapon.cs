using UnityEngine;
using System.Collections;

public class ProjectileWeapon : Weapon
{
	[Header("Shooting settings")]
	[SerializeField] private Transform barrel;
	[SerializeField] private Bullet projectile;
	[SerializeField] private float muzzleVelocity;
	[SerializeField] private float shotsPerMinute = 400f;
	[SerializeField] private AudioSource shootSound;
	[Header("IK Settings")]
	[SerializeField] private Transform rightHandIKTarget;
	[SerializeField] private Transform leftHandIKTarget;
	[SerializeField] private Transform rightElbowIKHint;
	[SerializeField] private Transform leftElbowIKHint;

	public Transform RightHandIKTarget { get { return rightHandIKTarget; } }
	public Transform LeftHandIKTarget { get { return leftHandIKTarget; } }
	public Transform LeftElbowIKHint { get { return leftElbowIKHint; } }
	public Transform RightElbowIKHint { get { return rightElbowIKHint; } }

	private bool shooting = false;
	private float timeNextShotIsReady;

	private void Awake()
	{
		timeNextShotIsReady = Time.time;
	}

	private void Start()
	{
		shootSound = GameObject.FindGameObjectWithTag ("ShootSound").GetComponent<AudioSource> ();
	}

	private void Update()
	{
		if (timeNextShotIsReady < Time.time)
		{
			if (shooting)
			{
				var spawnedBullet = Instantiate (projectile, barrel.position, barrel.rotation) as Bullet;
				shootSound.Play ();
				spawnedBullet.SetDamage(damage);
				spawnedBullet.gameObject.layer = gameObject.layer;
//				spawnedBullet.IgnoreCollision (GetComponentInParent<Player> ().GetComponent<Collider> ());
				spawnedBullet.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.forward * muzzleVelocity, ForceMode.VelocityChange);
				timeNextShotIsReady += 60f / shotsPerMinute;
			}
			else
			{
				timeNextShotIsReady = Time.time;
			}
		}
	}

	#region implemented abstract members of Weapon
	public override void StartAttack ()
	{
		shooting = true;
	}
	public override void EndAttack ()
	{
		shooting = false;
	}
	public override bool AIShouldAttack(Vector3 target)
	{
		var weaponToTarget = target - barrel.position;
		if (weaponToTarget.sqrMagnitude > Mathf.Pow (aiRangedAttackRange, 2f))
		{
			return false;
		}

		return Vector3.Angle (barrel.forward, weaponToTarget) < aiRangedAttackAngle;
	}
	#endregion
}