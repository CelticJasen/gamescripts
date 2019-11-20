using UnityEngine;
using System.Collections;

public class Player : Agent
{
	public void Killed()
	{
		HandleOnDie ();
	}

	protected override void Awake()
	{
		base.Awake ();
		Toolbox.Player = this;
	}

	private void Start()
	{
		Toolbox.UIManager.RegisterPlayer (this);
	}

	protected override void HandleOnDie()
	{
		base.HandleOnDie ();
		Toolbox.Player = null;
	}

	// Update is called once per frame
	protected override void Update ()
	{
		base.Update ();

		if (Toolbox.GameManager.Paused)
		{
			return;
		}

		/// <summary>
		/// Deals with the player input and gives it to the animator
		/// </summary>
		var input = new Vector3 (Input.GetAxis ("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
		input = transform.InverseTransformDirection (input);
		Animator.SetFloat ("Horizontal", input.x);
		Animator.SetFloat ("Vertical", input.z);

		// Rotation
		var plane = new Plane (Vector3.up, transform.position);
		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float distance;
		if (plane.Raycast (ray, out distance))
		{
			transform.LookAt (ray.GetPoint (distance), Vector3.up);
		}

		// Actions
		if (Input.GetKeyDown (KeyCode.Space))
		{
			Animator.SetTrigger ("Jump");
		}

		if (Input.GetKey (KeyCode.C))
		{
			Animator.SetBool ("Crouch", true);
		}
		else
		{
			Animator.SetBool ("Crouch", false);
		}

		if (EquippedWeapon)
		{
			if (Input.GetButtonDown ("Attack"))
			{
				EquippedWeapon.StartAttack ();
			}
			if (Input.GetButtonUp ("Attack"))
			{
				EquippedWeapon.EndAttack ();
			}
		}
	}
}