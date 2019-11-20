using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class OpenInventory : MonoBehaviour
{
	public Image inventory;
	private GameObject[] slots;
	private GameObject[] stacks;

	// Use this for initialization
	void Start ()
	{
		inventory.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		GameObject[] slots = GameObject.FindGameObjectsWithTag("Slot");
		GameObject[] stacks = GameObject.FindGameObjectsWithTag("Stack");

		if (Input.GetKeyDown(KeyCode.I))
		{
			inventory.enabled = !inventory.enabled;
		}

		foreach (var obj in slots)
		{
			obj.GetComponent<Image>().enabled = inventory.enabled;
			obj.GetComponent<Button>().enabled = inventory.enabled;
		}
		foreach (var obj in stacks)
		{
			obj.GetComponent<Text>().enabled = inventory.enabled;
		}
	}
}
