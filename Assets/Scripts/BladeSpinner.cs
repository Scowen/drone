using UnityEngine;
using System.Collections;

public class BladeSpinner : MonoBehaviour {

	[Range(1000,3000)]
	public float bladeSpeed = 1500;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * bladeSpeed * Time.deltaTime);
	}
}
