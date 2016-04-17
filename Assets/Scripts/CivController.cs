using UnityEngine;
using System.Collections;

public class CivController : MonoBehaviour {

	private float waitTime;
	private float counter;
	private Vector3 target;

	public float speed;

	// Use this for initialization
	void Start () {
		counter = waitTime;
		waitTime = Random.Range (5, 20);
		this.target = FindRandomPointRelative ();
	}

	// Update is called once per frame
	void Update () {
		this.counter -= Time.deltaTime;

		if (counter <= 0) {
			counter = waitTime;
			target = FindRandomPointRelative ();

		}
		Vector3 movement = (this.target - this.transform.position);
		movement.Normalize ();
		float step = speed * Time.deltaTime;
		movement.Scale (new Vector2 (step, step));
		this.transform.position += movement;
	}

	Vector2 FindRandomPointRelative() {
		float x = Random.value * 10 - 5;
		float y = Random.value * 10 - 5;
		return transform.position + new Vector3(x,y,0);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag.Equals("Player")) {
			Destroy(this.gameObject);
		}
	}
}
