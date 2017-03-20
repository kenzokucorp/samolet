using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLimits : MonoBehaviour {

	private Transform theTransform = null;
	public Vector2 horizontalRange = Vector2.zero;

	void Awake() {
		theTransform = GetComponent<Transform> ();
	}

	void LateUpdate() {
		theTransform.position = new Vector3 (
			Mathf.Clamp (theTransform.position.x, horizontalRange.x, horizontalRange.y),
			theTransform.position.y,
			theTransform.position.z);
	}
}
