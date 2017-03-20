using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawner : MonoBehaviour {

	public GameObject[] effects;
	public Vector3 spawnValues;
	public float spawnWait;
	public int startWait;
	public float spawnMostWait;
	public float spawnLeastWait;
	public bool stop;

	private int randomEnemy;

	void Start () {
		StartCoroutine (WaitSpawner());
	}

	void Update () {
		spawnWait = Random.Range (spawnLeastWait, spawnMostWait);
	}

	IEnumerator WaitSpawner() {
		yield return new WaitForSeconds (startWait);

		while (!stop) {
			randomEnemy = Random.Range (0,2);
			Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), 1, 
				Random.Range(-spawnValues.z, spawnValues.z));

			Instantiate (effects[randomEnemy], 
				spawnPosition + transform.TransformPoint(0, 0, 0), 
				gameObject.transform.rotation);

			yield return new WaitForSeconds (spawnWait);
		}
	}
}
