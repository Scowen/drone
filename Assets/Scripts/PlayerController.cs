using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float minThrust = 460;
	public float idleThrust = 490;
	public float maxThrust = 510;
	public float acceleration = 500;
	public float bankSpeed = 60;
	public float rotateSpeed = 1.2f;
	public float maxTilt = 45;

	private Rigidbody rb;
	private float thrust;

	void Start () {
		rb = GetComponent<Rigidbody>();	
		thrust = idleThrust;
	}
	
	void Update () {
		if (Input.GetKey (KeyCode.W)) {
			thrust = maxThrust;
		} else if (Input.GetKey(KeyCode.S)) {
			thrust = minThrust;
		} else {
			thrust = idleThrust;
		}
	}

	// Any force updates.
	void FixedUpdate() {
		rb.AddForce (transform.up * thrust * Time.deltaTime);

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (Vector3.left * bankSpeed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (Vector3.right * bankSpeed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Rotate (Vector3.forward * bankSpeed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Rotate (Vector3.back * bankSpeed * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.Rotate (0, -rotateSpeed, 0);
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.Rotate (0, rotateSpeed, 0);
		}
	}
}
