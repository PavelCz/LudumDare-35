using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;

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
		
		int horizontal = 0;
		int vertical = 0;

		bool up = Input.GetKey(KeyCode.W);
		bool down = Input.GetKey(KeyCode.S);
		bool left = Input.GetKey(KeyCode.A);
		bool right = Input.GetKey(KeyCode.D);

		if (up) {
			vertical++;
		}
		if (down) {
			vertical--;
		}
		if(left) {
			horizontal--;
		}
		if(right) {
			horizontal++;
		}
		float distance = speed * delta;

		Vector2 movement = new Vector2 (horizontal, vertical);
		movement.Normalize ();
		movement.Scale (new Vector2(distance, distance));

		this.activeGameObject.transform.Translate (movement);
	}

	void UpdateMode() {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			this.mode = 0;
			this.car.SetActive (true);
			this.mech.SetActive (false);
			this.car.transform.position = this.activeGameObject.transform.position;
			this.activeGameObject = this.car;

		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			this.mode = 1;
			this.car.SetActive (false);
			this.mech.SetActive (true);
			this.mech.transform.position = this.activeGameObject.transform.position;
			this.activeGameObject = this.mech;
		}
	}
}
