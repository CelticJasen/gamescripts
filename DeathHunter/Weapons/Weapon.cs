using UnityEngine;
using System.Collections;

[DisallowMultipleComponent]
public abstract class Weapon : MonoBehaviour
{
	public enum Animation
	{
		None = 0,
		Ranged = 1,
		Melee = 2
	}

	[SerializeField] private Animation animationType;
	[SerializeField] protected float damage;
	[Header("UI Settings")]
	[SerializeField] private Sprite icon;
	[Header("AI Settings")]
	[SerializeField, Range(0f, 100f)] protected float aiRangedAttackAngle = 5f;
	[SerializeField] protected float aiRangedAttackRange = 5f;
	[SerializeField, Range(0f, 100f)] protected float aiAttackAngle = 20f;
	[SerializeField] protected float aiAttackRange = 2f;

	public Sprite Icon { get { return icon; } }

	public Animation AnimationType
	{
		get { return animationType; }
	}

	public abstract bool AIShouldAttack (Vector3 target);

	public abstract void StartAttack ();
	public abstract void EndAttack ();
}