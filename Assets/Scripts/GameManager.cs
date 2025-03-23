using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public List<GameObject> targets;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		StartCoroutine(SpawnTarget());
	}

	// Update is called once per frame
	void Update() {
	}

	IEnumerator SpawnTarget() {
		while (true) {
			yield return new WaitForSeconds(1.5f);
			int index = Random.Range(0, targets.Count);
			Instantiate(targets[index]);
		}
	}
}