using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	public static PlayerController player = null;

	public bool canJump = true;
	public bool canMove = true;
	public bool isOnTheGround = false;

	public float jumpPower = 400.0f;
	public float jumpTimeout = 1.0f;
	public float maxSpeed = 40.0f;

	public string horizontalAxis = "Horizontal";
	public string verticalAxis = "Vertical";
	public string jumpButton = "Jump";

	public BoxCollider feetCollider = null;
	public LayerMask groundLayer;

	private Rigidbody theRigidbody = null;
	private Transform theTransform = null;

	public static float Health {
		get { 
			return _health;
		}
		set { 
			_health = value;
			if (_health <= 0) {
				Die ();
			}
		}
	}

	[SerializeField]
	private static float _health = 100.0f;

	void Awake () {
		player = this;
		theRigidbody = GetComponent<Rigidbody> ();
		theTransform = GetComponent<Transform> ();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	private void Jump() {
		if (!isOnTheGround || !canJump) {
			return;
		} else {
			theRigidbody.AddForce (Vector2.up * jumpPower);
			canJump = false;
			Invoke ("EnableJump", jumpTimeout);
		}
	}

	private void EnableJump () {
		canJump = true;
	}

	private bool GetGrounded() {
		//VECTOR 3 sumar offset
		Vector3 boxCenter = feetCollider.center;
		Collider2D[] hitColliders = Physics2D.OverlapBoxAll (boxCenter, feetCollider.size, groundLayer);
		return hitColliders.Length > 0;
	}

	private void ChangeDirection() {
		//direction = (FACE_DIRECTION)((int)direction * -1.0f);
		Vector3 localScale = theTransform.localScale;
		localScale.x *= -1.0f;
		theTransform.localScale = localScale;
	}

	void FixedUpdate () {
		if (!canMove || Health <= 0)
			return;

		isOnTheGround = GetGrounded ();

		float horizontal = CrossPlatformInputManager.GetAxis (horizontalAxis);
		theRigidbody.AddForce (Vector2.right * horizontal * maxSpeed);

		if ((horizontal < 0) || (horizontal > 0)) {
			ChangeDirection ();
		}

		if (CrossPlatformInputManager.GetButton (jumpButton))
			Jump ();

		theRigidbody.velocity = new Vector2 (
			Mathf.Clamp (theRigidbody.velocity.x, -maxSpeed, maxSpeed),
			Mathf.Clamp (theRigidbody.velocity.y, -Mathf.Infinity, jumpPower)
		);
	}

	void OnDestroy() {
		player = null;
	}

	static void Die() {
		Destroy (PlayerController.player.gameObject);
	}

	public static void Reset() {
		Health = 100.0f;
	}
}
