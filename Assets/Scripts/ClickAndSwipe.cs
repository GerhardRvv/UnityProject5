using UnityEngine;

[RequireComponent(typeof(TrailRenderer), typeof(BoxCollider))]

public class ClickAndSwipe : MonoBehaviour {
	
	private GameManager _gameManager;
	private Camera _camera;
	private Vector3 _mousePosition;

	private TrailRenderer _trail;
	private BoxCollider _boxCollider;
	private bool _swiping;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Awake() {
		_camera = Camera.main;
		_trail = GetComponent<TrailRenderer>();
		_boxCollider = GetComponent<BoxCollider>();
		
		_boxCollider.enabled = false;
		_trail.enabled = false;

		_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	// Update is called once per frame
	void Update() {
		if (_gameManager.isGameActive) {
			if (Input.GetMouseButtonDown(0)) {
				_swiping = true;
				UpdateComponents();
			} else if (Input.GetMouseButtonUp(0)) {
				_swiping = false;
				UpdateComponents();
			}

			if (_swiping) {
				UpdateMousePosition();
			}
		}
	}

	void UpdateMousePosition() {
		_mousePosition = _camera.ScreenToWorldPoint(
			new Vector3(
				Input.mousePosition.x,
				Input.mousePosition.y,
				10.0f
			)
		);
		transform.position = _mousePosition;
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.GetComponent<Target>()) {
			collision.gameObject.GetComponent<Target>().DestroyTarget();
		}
	}

	void UpdateComponents() {
		_trail.enabled = _swiping;
		_boxCollider.enabled = _swiping;
	}
}