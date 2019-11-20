using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssignmentScript : MonoBehaviour
{
	public GameObject assignmentNameButton;

	public void SetAssignment(string name)
	{
		this.assignmentNameButton.GetComponent<Text> ().text = name;
	}
}