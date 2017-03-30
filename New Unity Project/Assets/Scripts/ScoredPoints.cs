using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoredPoints : MonoBehaviour {

	private Text scored;

	void Awake() {
		scored = GetComponent<Text> ();
	}

	void Update() {
		int lastScore = PlayerPrefs.GetInt ("last_score");
		string userFeedback = "You scored " + lastScore + " points";
		scored.text = userFeedback;
	}
}
