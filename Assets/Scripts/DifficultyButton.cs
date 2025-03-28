using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour {

	private Button _button;
	private GameManager _gameManager;

	public int difficulty;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		_button = GetComponent<Button>();
		_button.onClick.AddListener(SetDifficulty);

		_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	// Update is called once per frame
	void Update() {
	}

	private void SetDifficulty() {
		Debug.Log(_button.gameObject.name + " was clicked.");
		_gameManager.StartGame(difficulty);
	}
}