﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float mechSpeed;

	public float carSpeed;

	public GameObject mech;
	public GameObject car;
	public GameObject activeGameObject { get; private set;}
	private int mode = 1;

	// Use this for initialization
	void Start () {
		this.activeGameObject = mech;
	}
	
	// Update is called once per frame
	void Update () { 
		float delta = Time.deltaTime;

		this.UpdateMode();

		bool up = Input.GetKey(KeyCode.W);
		bool down = Input.GetKey(KeyCode.S);
		bool left = Input.GetKey(KeyCode.A);
		bool right = Input.GetKey(KeyCode.D);

		if (this.mode == 1) {
			this.MechMovement (delta, up, down, left, right);
		} else {
			this.CarMovement (delta, up, down, left, right);
		}
	}

	void UpdateMode() {
		if (Input.GetKeyDown (KeyCode.E)) {
			this.mode = 0;
			this.car.SetActive (true);
			this.mech.SetActive (false);
			this.car.transform.position = this.activeGameObject.transform.position;
			this.activeGameObject = this.car;

		} else if (Input.GetKeyDown (KeyCode.Q)) {
			this.mode = 1;
			this.car.SetActive (false);
			this.mech.SetActive (true);
			this.mech.transform.position = this.activeGameObject.transform.position;
			this.activeGameObject = this.mech;
		}
	}

	void CarMovement(float delta, bool up, bool down, bool left, bool right) {
		if (up) {
			this.activeGameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (carSpeed * delta, 0));
		}
	}

	void MechMovement(float delta, bool up, bool down, bool left, bool right) {
		int horizontal = 0;
		int vertical = 0;


		if (Input.GetKey(KeyCode.W)) {
			Debug.Log ("W");
			vertical++;
		}
		if (Input.GetKey(KeyCode.S)) {
			vertical--;
		}
		if(Input.GetKey(KeyCode.A)) {
			horizontal--;
		}
		if(Input.GetKey(KeyCode.D)) {
			horizontal++;
		}
		float distance = mechSpeed * delta;

		Vector2 movement = new Vector2 (horizontal, vertical);
		movement.Normalize ();
		movement.Scale (new Vector2(distance, distance));

		this.activeGameObject.transform.Translate (movement);
	}
}
