﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;

	public GameObject mech;
	public GameObject car;
	private int mode = 1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			this.mode = 0;
			this.car.SetActive (true);
			this.mech.SetActive (false);
		}
		
		int horizontal = 0;
		int vertical = 0;

		bool n = Input.GetKey (KeyCode.W);
		bool s = Input.GetKey (KeyCode.S);
		bool w = Input.GetKey(KeyCode.A);
		bool e = Input.GetKey(KeyCode.D);

		if (n) {
			vertical++;
		}
		if (s) {
			vertical--;
		}
		if(w) {
			horizontal--;
		}
		if(e) {
			horizontal++;
		}
		float distance = speed * Time.deltaTime;

		Vector2 movement = new Vector2 (horizontal, vertical);
		movement.Normalize ();
		movement.Scale (new Vector2(distance, distance));

		this.gameObject.transform.Translate (movement);
	}
}
