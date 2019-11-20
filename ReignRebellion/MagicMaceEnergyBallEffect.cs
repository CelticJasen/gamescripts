using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMaceEnergyBallEffect : MonoBehaviour
{
	[Header("Ability Values")]
	[Tooltip("The projectile for this ability")]
	[SerializeField]
	private GameObject projectile;

	[Tooltip("The position of the game object the projectile is to be fired from")]
	[SerializeField]
	private Transform weapon;

	[Tooltip("The damage the projectile will do to an enemy")]
	[SerializeField]
	private float damage;

	[Tooltip("The velocit the projectile will travel")]
	[SerializeField]
	private float projectileVelocity;

	[Tooltip("The name tag of the user's team")]
	[SerializeField]
	private string myTeam;

	private void FireProjectile()
	{
		/*Be sure to have the weapon aimed properly when this happens or else the projectile could fly off in weird directions
		as the projectile's rotation is based on weapon rotation and whichever way the projectile is facing forward is the direction it will go*/
		var spawnedProjectile = Instantiate (projectile, weapon.position, weapon.rotation) as GameObject;
		spawnedProjectile.GetComponent<MagicMaceProjectile>().SetDamage(damage);
		spawnedProjectile.GetComponent<MagicMaceProjectile>().SetTeam(myTeam);
		spawnedProjectile.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.forward * projectileVelocity, ForceMode.VelocityChange);
	}
}