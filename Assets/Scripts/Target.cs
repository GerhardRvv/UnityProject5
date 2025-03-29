using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour {
	
	private Rigidbody _targetRb;
	private GameManager _gameManager;
	public ParticleSystem explosionParticle;
	
	private float _minSpeed = 3400;
	private float _maxSpeed = 3600;
	
	private float _maxTorque = 400;
	private float _xRange = 4;
	private float _ySpawnPos = 0;
	
	public int pointValue;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		_targetRb = GetComponent<Rigidbody>();
		_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		
		var speed = Random.Range(_minSpeed, _maxSpeed);

		_targetRb.AddForce(
			Vector3.up * (speed * Time.deltaTime),
			ForceMode.Impulse
		);
		
		_targetRb.AddTorque(
			RandomTorque(),
			RandomTorque(),
			RandomTorque(),
			ForceMode.Impulse
		);

		transform.position = new Vector3(
			Random.Range(-_xRange, _xRange),
			_ySpawnPos
		);
	}

	private float RandomTorque() {
		var torque = Random.Range(-_maxTorque, _maxTorque);
		return torque * Time.deltaTime;
	}

	// Update is called once per frame
	void Update() {
	}

	private void OnMouseDown() {
		if (_gameManager.isGameActive) {
			Destroy(gameObject);
			Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
			_gameManager.UpdateScore(pointValue);
		}
	}

	private void OnTriggerEnter(Collider other) {
		Destroy(gameObject);
		if (!gameObject.CompareTag("BadItem")) {
			_gameManager.GameOver();
		}
	}
}