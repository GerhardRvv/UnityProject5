using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Target : MonoBehaviour {
	private Rigidbody _targetRb;
	private float _minSpeed = 3200;
	private float _maxSpeed = 3500;
	
	private float _maxTorque = 100;
	private float _xRange = 4;
	private float _ySpawnPos = 0;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		_targetRb = GetComponent<Rigidbody>();
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
		Destroy(gameObject);
	}

	private void OnTriggerEnter(Collider other) {
		Destroy(gameObject);
	}
}