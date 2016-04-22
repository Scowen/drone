﻿using UnityEngine;
using System.Collections;

public class CameraFirstPerson : MonoBehaviour {

	public GameObject player;

	private Camera cameraComponent;

	// Use this for initialization
	void Start () {
		transform.parent = player.transform;
		transform.position = new Vector3 (0, 0, 0);
		cameraComponent = GetComponent<Camera> ();
		cameraComponent.fieldOfView = 60;
		transform.Rotate(new Vector3(-20, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}