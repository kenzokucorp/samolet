using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindRandomizer : MonoBehaviour {

	private Rigidbody theRigidbody = null;
	private Transform theTransform = null;
	private float maxSpeed = 7.5f;
	private int maxRandomTime = 3;

	void Awake () {
		theRigidbody = GetComponent<Rigidbody> ();
		theTransform = GetComponent<Transform> ();
	}

	// Use this for initialization
	void Start () {
		StartCoroutine (Randomize ());
	}

	IEnumerator Randomize() {
		while (true) {
			yield return new WaitForSeconds(Random.Range(1,maxRandomTime));
			float horizontal = Random.Range(-20, 20);
			theRigidbody.AddForce (Vector2.right * horizontal * maxSpeed);
			theTransform.Rotate (new Vector3 (0.0f, 0.0f, -horizontal * (maxSpeed/10)));
			if (maxRandomTime > 5) {
				maxRandomTime -= 1;
			}
		}
	}

}
