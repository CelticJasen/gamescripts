using UnityEngine;
using System.Collections;

public class HealthPickUp : PickUp
{
	[SerializeField] private float healthAmount = Mathf.Infinity;

	#region implemented abstract members of PickUp
	protected override void PickThisUp (Player player)
	{
		player.Health.Modify(healthAmount);
	}
	#endregion
}