using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public List<GameObject> targets;
	public TextMeshProUGUI livesText;
	private int _lives = 3;

	public TextMeshProUGUI scoreText;
	public TextMeshProUGUI gameOverText;

	public GameObject pauseGamePanel;
	private bool _isPaused;

	public Button restartButton;
	public GameObject gameTitleGroup;

	public bool isGameActive;
	private int _score;
	private float _spawnRate = 1.5f;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
	}

	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown(KeyCode.P)) {
			ChangePaused();
		}
	}

	IEnumerator SpawnTarget() {
		while (isGameActive) {
			yield return new WaitForSeconds(_spawnRate);
			int index = Random.Range(0, targets.Count);
			Instantiate(targets[index]);
		}
	}

	public void UpdateScore(int scoreToAdd) {
		_score += scoreToAdd;
		scoreText.text = "Score: " + _score;
	}

	public void UpdateLives(int livesToChange) {
		_lives += livesToChange;
		livesText.text = "Lives: " + _lives;
		if (_lives <= 0) {
			GameOver();
		}
	}

	public void GameOver() {
		restartButton.gameObject.SetActive(true);
		gameOverText.gameObject.SetActive(true);
		isGameActive = false;
	}

	public void RestartGame() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void StartGame(int difficulty) {
		isGameActive = true;
		_score = 0;

		_spawnRate /= difficulty;

		StartCoroutine(SpawnTarget());
		UpdateScore(0);
		UpdateLives(3);
		gameTitleGroup.gameObject.SetActive(false);
	}

	void ChangePaused() {
		if (!_isPaused) {
			_isPaused = true;
			pauseGamePanel.SetActive(true);
			Time.timeScale = 0;
		} else {
			_isPaused = false;
			pauseGamePanel.SetActive(false);
			Time.timeScale = 1;
		}
	}
}