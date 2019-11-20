using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[DisallowMultipleComponent]
public class Health : MonoBehaviour
{
	[Header("Events")]
	[Tooltip("A number of events raised by this component.")]
	public Events events;

	[System.Serializable]
	public struct Events
	{
		public FloatUnityEvent onChange;
		public FloatUnityEvent onDamage;
		public FloatUnityEvent onHeal;
		public UnityEvent onDie;
	}

	[Header("Settings")]
	[SerializeField, Tooltip("The initial health.")] private float initialValue;
	[SerializeField, Tooltip("The max health.")] private float maxValue;

	[SerializeField]
	private float currentValue;

	public float Value
	{
		get { return currentValue; }
	}

	public float Percent
	{
		get { return currentValue / maxValue; }
	}

	public void Modify(float change)
	{
		if (!enabled)
		{
			return;
		}

		float newValue = Mathf.Clamp (currentValue + change, 0f, maxValue);
		float actualChange = currentValue - newValue;
		events.onChange.Invoke (actualChange);

		if (actualChange < 0f)
		{
			events.onDamage.Invoke (actualChange);
		} 
		else if (actualChange > 0f)
		{
			events.onHeal.Invoke (actualChange);
		}

		currentValue = newValue;

		if (currentValue == 0)
		{
			events.onDie.Invoke ();
			enabled = false;
		}
	}

	private void Awake()
	{
		Modify (initialValue);
	}
}