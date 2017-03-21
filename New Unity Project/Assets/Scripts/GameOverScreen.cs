using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour {

	private RectTransform panel;

	void Awake() {
		panel = GetComponent<RectTransform> ();
		panel.gameObject.SetActive (false);
	}

	public void ShowGameOver() {
		panel.gameObject.SetActive (true);
	}
}
