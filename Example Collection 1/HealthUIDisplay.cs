using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthUIDisplay : MonoBehaviour
{
	public Text label;
	public Health healthToDisplay;

	private void Update()
	{
		label.text = string.Format("{0}: {1} HP, {2}", healthToDisplay.name, healthToDisplay.Value, healthToDisplay.Percent);
	}
}