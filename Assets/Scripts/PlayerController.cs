using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// [Range(400,600)]
	public float minThrust = 460;
	// [Range(400,600)]
	public float idleThrust = 490;
	// [Range(400,600)]
	public float maxThrust = 510;
// 	[Range(400,600)]
	public float bankSpeed = 40;

	public float rotateSpeed = 1.2f;


	// The maximum that the drone can tilt in degrees.
	public float maxTilt = 45;

	private Rigidbody rb;
	private float thrust;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();	
		thrust = idleThrust;
	}
	
	// Update is called once per frame
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
