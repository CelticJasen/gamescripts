using UnityEngine;
using System.Collections;

public class WeaponPickUp : PickUp
{
	[SerializeField] private Weapon weapon;

	#region implemented abstract members of PickUp
	protected override void PickThisUp (Player player)
	{
		player.EquipWeapon (weapon);
	}
	#endregion
}