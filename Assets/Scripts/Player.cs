using UnityEngine;
using System.Collections;

public class Player : Character {
	
	private Animator animator;

	private Rigidbody2D rigidbody2D;

	void Start () {
		animator = GetComponent<Animator> ();
		rigidbody2D = GetComponent<Rigidbody2D> ();
	}

	protected override void Update () {
		GetInput ();

		base.Update ();
	}

	public void GetInput(){
		
		direction = Vector2.zero;
		bool attack = Input.GetButton ("Attack");
		if (attack)
			animator.SetTrigger ("attack");
		animator.SetTrigger ("idle");

		bool jump = Input.GetButtonDown ("Jump");
		if (jump)
			rigidbody2D.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
		/*
		bool run_left = Input.GetKey (KeyCode.LeftArrow);
		bool run_right = Input.GetKey (KeyCode.RightArrow);
		if (run_right) {
			direction += Vector2.left;
		}
		if (run_left) {
			direction += Vector2.right;
		}
		animator.SetBool ("run", run_left);*/
	}
}
