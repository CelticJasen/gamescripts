using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	[SerializeField] private Text label;
	[SerializeField] private string labelFormat = "Health: {0}";
	[SerializeField] private Image fill;
	[SerializeField] private bool trackTarget = false;
	[SerializeField] private Vector3 offset = Vector3.up * 2f;
	[SerializeField] private bool destroyWithTarget = false;

	private Health health;

	public void Register (Health health)
	{
		this.health = health;
		if (destroyWithTarget)
		{
			health.events.onDie.AddListener (HandleTargetDied);
		}
	}

	private void HandleTargetDied()
	{
		Destroy(gameObject);
	}

	private void Update()
	{
		if (health)
		{
			if (label)
			{
				label.text = string.Format (labelFormat, health.Value);
			}
			if (fill)
			{
				fill.fillAmount = health.Percent;
			}

			// set our position
			if (trackTarget)
			{
				var position = Camera.main.WorldToScreenPoint (health.transform.position + offset);
				position.z = 0;
				transform.position = position;
			}
		}
	}
}