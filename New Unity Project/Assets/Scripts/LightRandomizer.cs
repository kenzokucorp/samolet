using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRandomizer : MonoBehaviour {

	private GameObject lightGameObject;
	private Light lightComp;
	private GameObject light;
	private int maxRandomTime = 15;

	void Start() {
		light = GameObject.FindGameObjectWithTag ("Light");
		lightGameObject = new GameObject("The Light");
		lightComp = lightGameObject.AddComponent<Light>();
		StartCoroutine (Randomize ());
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator Randomize() {
		while (true) {
			yield return new WaitForSeconds(Random.Range(1,maxRandomTime));
			lightComp.color = Random.ColorHSV ();
			light.transform.position = new Vector3(Random.Range (-10, 10), Random.Range (-10, 10), 0);
			light.transform.rotation = Quaternion.Euler (new Vector3 (Random.Range (0, 360), Random.Range (0, 360), 0));
			if (maxRandomTime > 5) {
				maxRandomTime -= 1;
			}
		}
	}
}
