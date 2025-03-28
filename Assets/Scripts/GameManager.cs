using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public List<GameObject> targets;
	
	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI gameOverText;
	
	public Button restartButton;
	
	public bool isGameActive;
	private int _score;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		isGameActive = true;
		_score = 0;

		StartCoroutine(SpawnTarget());
	}

	// Update is called once per frame
	void Update() {
	}

	IEnumerator SpawnTarget() {
		while (isGameActive) {
			yield return new WaitForSeconds(1.5f);
			int index = Random.Range(0, targets.Count);
			Instantiate(targets[index]);
		}
	}

	public void UpdateScore(int scoreToAdd) {
		_score += scoreToAdd;
		scoreText.text = "Score: " + _score;
	}

	public void GameOver() {
		restartButton.gameObject.SetActive(true);
		gameOverText.gameObject.SetActive(true);
		isGameActive = false;
	}

	public void RestartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}