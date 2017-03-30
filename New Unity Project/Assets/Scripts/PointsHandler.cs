using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsHandler : MonoBehaviour {

	public Health health;
	private Text pointsScored;
	private int millisecondStarted;
	private int currentMillisecond;
	private int currentPoints;
	private int finalPoints;
	private GameObject pointsGUI;

	void Awake() {
		pointsScored = GetComponent<Text> ();
		pointsGUI = GameObject.FindGameObjectWithTag ("Points GUI");
		pointsGUI.SetActive (true);
	}

	// Use this for initialization
	void Start () {
		millisecondStarted = System.DateTime.Now.Millisecond;
		currentMillisecond = System.DateTime.Now.Millisecond;
		currentPoints = 0;
		pointsScored.text = "0";
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (health != null) {
			string pointsToDisplay = "";
			currentMillisecond = System.DateTime.Now.Millisecond;
			int deltaPoints = Mathf.Abs(currentMillisecond - millisecondStarted) / 10;
			currentPoints += deltaPoints;
			pointsToDisplay += currentPoints;
			pointsScored.text = pointsToDisplay;
		} else {
			if (finalPoints != null && finalPoints != currentPoints) {
				finalPoints = currentPoints;
				int lastScore = PlayerPrefs.GetInt ("user_score");
				if (finalPoints > lastScore) {
					PlayerPrefs.SetInt ("user_score", finalPoints);
				}
				PlayerPrefs.SetInt ("last_score", finalPoints);
				pointsGUI.SetActive (false);
			}
		}
	}
}
