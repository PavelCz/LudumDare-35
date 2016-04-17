using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float mechSpeed;

	public float carSpeed;
	public float carTurnSpeed;

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
			this.UpdateMech (delta, up, down, left, right);
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
		Rigidbody2D body = this.activeGameObject.GetComponent<Rigidbody2D> ();
		Transform transform = this.activeGameObject.transform;

		if (up) {
			body.AddRelativeForce (new Vector2 (-carSpeed * delta, 0));
		}
		if (down) {
			body.AddForce (new Vector2 (carSpeed * delta, 0));
		}
		if (left) {
			body.AddTorque (carSpeed * delta);
		}
		if (right) {
			body.AddTorque (-carSpeed * delta);
		}
	}

	void UpdateMech(float delta, bool up, bool down, bool left, bool right) {
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

		Vector2 mouse = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		float width = (mouse.x) - this.activeGameObject.transform.position.x;
		float height = (mouse.y) - this.activeGameObject.transform.position.y;

		float angle = Mathf.Atan2 (height, width) * Mathf.Rad2Deg;

		this.activeGameObject.transform.rotation = Quaternion.Euler(new Vector3(0,0,angle-90));
	}
}
