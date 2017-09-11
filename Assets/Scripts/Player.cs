using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// movement variables
	public float maxSpeed;
	bool facingRight;

	// jumping variables
	bool grounded = false;
	float groundCheckRadius = 0.2f;
	public LayerMask groundLayer;
	public Transform groundCheck;
	public float jumpHeight;

	private Animator animator;

	private Rigidbody2D rigidbody2D;

	void Start () {
		animator = GetComponent<Animator> ();
		rigidbody2D = GetComponent<Rigidbody2D> ();
		facingRight = true;
	}

	void Update (){
		if (grounded && Input.GetAxis ("Jump") > 0) {
			grounded = false; //p/ nao pular no ar
			animator.SetBool ("isGrounded", grounded);
			rigidbody2D.AddForce(new Vector2(0, jumpHeight));
		}

		// slide
		bool slide = Input.GetButtonDown ("Slide");
		animator.SetBool ("slide", slide);

	}

	void FixedUpdate () {

		// check if grounded
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, groundLayer);
		animator.SetBool ("isGrounded", grounded);

		animator.SetFloat ("verticalSpeed", rigidbody2D.velocity.y);

		// move
		float move = Input.GetAxis ("Horizontal");
		animator.SetFloat ("speed", Mathf.Abs (move));

		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		if (move > 0 && !facingRight) {
			flip ();
		} else if (move < 0 && facingRight) {
			flip ();
		}
	}

	void flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
