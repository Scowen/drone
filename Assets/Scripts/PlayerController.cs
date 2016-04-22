using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float minThrust = 0; // The minimum thrust that can be applied.
	public float idleThrust = 122.5f; // The amount needed to make the drone hover.
	public float maxThrust = 250; // The maximum thrust that can be applied.
	public float rotateSpeed = 2.2f; // The speed in which the drone can rotate.
	public float tiltSpeed = 4.4f; // The speed in which the drone will try to bank and pitch.
	public float maxTilt = 65.0f; // The maximum angle in degrees that the drone may tilt to.

	private Rigidbody rb;
	private float thrust; // The level of thrust being applied to the drone.
	private bool hover = true; // The Drone will hover using the idleThrust variable.
	private bool flipLock = true; // If the drone should be allowed to flip, toggleable.

	private float angleBank; // The desired angle of the bank.
	private float anglePitch; // The desired angle of the pitch.
	private float angleYaw; // The desired angle of the yaw.

	void Start () {
		rb = GetComponent<Rigidbody>();	

		// Need to set the angleYaw, otherwise it will "null out".
		angleYaw = 0;
	}
	
	void Update () {
		// Hover toggle.
		if (Input.GetKey (KeyCode.H)) 
			hover = hover == true ? false : true;

		// Flip toggle.
		if (Input.GetKey (KeyCode.F)) 
			flipLock = flipLock == true ? false : true;

		// Thrust control.
		if (Input.GetKey (KeyCode.W)) {
			thrust = maxThrust;
			// hover = false;
		} else if (Input.GetKey (KeyCode.S)) {
			thrust = minThrust;
			// hover = false;
		} else if (hover) {
			thrust = idleThrust;
		} else {
			thrust = 0;
		}

		// Angles for banking upon key press.
		if (Input.GetKey (KeyCode.LeftArrow))
			angleBank = -maxTilt;
		else if (Input.GetKey (KeyCode.RightArrow))
			angleBank = maxTilt;
		else
			angleBank = 0;

		// Angles for pitching upon key press.
		if (Input.GetKey (KeyCode.DownArrow))
			anglePitch = -maxTilt;
		else if (Input.GetKey (KeyCode.UpArrow))
			anglePitch = maxTilt;
		else
			anglePitch = 0;

		if (Input.GetKey (KeyCode.A))
			angleYaw -= rotateSpeed;
		else if (Input.GetKey (KeyCode.D))
			angleYaw += rotateSpeed;
	}

	// Any physics updates.
	void FixedUpdate() {
		// Apply thrust.
		rb.AddForce (transform.up * thrust * Time.deltaTime);

		// Tell the drone what angle we would like it to bank to.
		Vector3 targetAngle = new Vector3 (angleBank, angleYaw, anglePitch);
		Vector3 currentAngle = transform.eulerAngles;

		// Set the rotation using Lerp. (No idea what it is, don't worry).
		currentAngle = new Vector3 (
			Mathf.LerpAngle (currentAngle.x, targetAngle.x, Time.deltaTime * tiltSpeed),
			Mathf.LerpAngle (currentAngle.y, targetAngle.y, Time.deltaTime * tiltSpeed),
			Mathf.LerpAngle (currentAngle.z, targetAngle.z, Time.deltaTime * tiltSpeed)
		);

		// Set the rotation angle.
		transform.eulerAngles = currentAngle;
	}
}
