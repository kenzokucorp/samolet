using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saving : MonoBehaviour {

	public void SaveScore(int score) {
		PlayerPrefs.SetInt ("user_score", score);
	}
}
