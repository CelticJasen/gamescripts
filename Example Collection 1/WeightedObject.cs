using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class WeightedObject
{
	[SerializeField] private GameObject value;
	[SerializeField] private double chance = 1.0;

	private static System.Random rnd = new System.Random ();

	public static GameObject Select(WeightedObject[] objects)
	{
		double[] cdfArray = new double[objects.Length];
		double total = 0;
		for (int index = 0; index < objects.Length; index++)
		{
			total += objects [index].chance;
			cdfArray [index] = total;
		}

		int selectedIndex = System.Array.BinarySearch (cdfArray, rnd.NextDouble () * total);

		if (selectedIndex < 0)
		{
			selectedIndex = ~selectedIndex;
		}
		return objects [selectedIndex].value;
	}
}