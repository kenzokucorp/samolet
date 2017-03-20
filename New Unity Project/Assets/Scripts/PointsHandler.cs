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

	void Awake() {
		pointsScored = GetComponent<Text> ();
	}

	// Use this for initialization
	void Start () {
		millisecondStarted = System.DateTime.Now.Millisecond;
		currentMillisecond = System.DateTime.Now.Millisecond;
		currentPoints = 0;
		pointsScored.text = "0";
	}

	// Update is called once per frame
	void Update () {
		if (health != null) {
			string pointsToDisplay = "";
			currentMillisecond = System.DateTime.Now.Millisecond;
			int deltaPoints = currentMillisecond - millisecondStarted;
			currentPoints += deltaPoints;
			pointsToDisplay += currentPoints;
			pointsScored.text = pointsToDisplay;
		} else {
			if (finalPoints != null) {
				finalPoints = currentPoints;
			}
		}
	}
}
