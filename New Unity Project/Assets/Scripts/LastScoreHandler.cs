using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastScoreHandler : MonoBehaviour {

	private Text lastScore;

	void Awake() {
		lastScore = GetComponent<Text> ();
		lastScore.text = "" + PlayerPrefs.GetInt ("user_score");
	}
}
