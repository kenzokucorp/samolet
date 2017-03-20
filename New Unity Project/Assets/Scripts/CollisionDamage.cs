using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour {

	public float damagePoints = 100.0f;

	void OnTriggerStay(Collider otherCollider) {
		Health health = otherCollider.gameObject.GetComponent<Health> ();

		if (health == null)
			return;

		health.healthPoints -= damagePoints;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
