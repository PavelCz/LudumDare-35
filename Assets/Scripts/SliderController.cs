using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderController : MonoBehaviour {
	public float risingSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerController.MODE == 0) {
			this.gameObject.GetComponent<Slider> ().value += risingSpeed * Time.deltaTime;
		}
	}
}
