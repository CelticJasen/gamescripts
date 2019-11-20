using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthEffect : MonoBehaviour
{
	private bool isStealth = false;

	[Header("Stealth Materials")]
	[SerializeField]
	private Material invisibleMaterial;
	[SerializeField]
	private Material partiallyInvisibleMaterial;
	[Tooltip("This is for the original material of the player")]
	[SerializeField]
	private Material normalMaterial;

	//The player may be part of a component system where the player's charactercontroller or rigidbody or whatever is on a
	//different (usually main) component so I added this here as a solution if that's the case
	[Space (20)]
	[Tooltip("Stick the main component of the player in here")]
	[SerializeField]
	private GameObject mainComponent;

	void Update()
	{
		if (isStealth == true)
		{
			//Checks the character controller for movement. This can be changed to Rigidbody if you're not using a CharacterController
			if (mainComponent.GetComponent<CharacterController>().velocity != Vector3.zero)
			{
				//Applies a material to the user. Change this to work with all materials on the player if needed
				gameObject.GetComponent<MeshRenderer> ().material = partiallyInvisibleMaterial;
			}
			else
			{
				//Applies a material to the user. Change this to work with all materials on the player if needed
				gameObject.GetComponent<MeshRenderer> ().material = invisibleMaterial;
			}
		}
	}

	//This sets isStealth to true and applies the invisible material to the Skinned Mesh Renderer
	public void StartStealth()
	{
		isStealth = true;
		//Applies a material to the user. Change this to work with all materials on the player if needed
		gameObject.GetComponent<MeshRenderer> ().material = invisibleMaterial;
	}

	public void EndStealth()
	{
		isStealth = false;
		//Applies a material to the user. Change this to work with all materials on the player if needed
		gameObject.GetComponent<MeshRenderer> ().material = normalMaterial;
	}
}