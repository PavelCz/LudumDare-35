using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
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

		Vector2 movement = new Vector2 (horizontal, vertical);
		movement.Normalize ();
		movement.Scale (new Vector2(speed * Time.deltaTime, speed* Time.deltaTime));

		this.gameObject.transform.Translate (movement);
	}
}
