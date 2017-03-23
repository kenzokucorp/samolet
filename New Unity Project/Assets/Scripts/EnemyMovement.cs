using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	private float speed;

	void Update() {
		speed = Random.Range (1.0f, 10.0f);
		transform.Translate(Vector3.back * Time.deltaTime * speed);

		if (transform.position.z < 0.0f) {
			Destroy (gameObject);
		}
	}
}
