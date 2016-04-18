using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderController : MonoBehaviour {
	public float risingSpeed;
	public float fallingSpeed;
	public Text gameOverText;

	// Use this for initialization
	void Start () {
	
	}


	
	// Update is called once per frame
	void Update () {
		// checks if this is last Civilian
		if (GameObject.FindGameObjectsWithTag("Civilian").Length <= 0) {
			gameOverText.gameObject.SetActive (true);
			gameOverText.text = "You rescued all civilians\nScore: " + CameraController.SCORE + "\n Press 'R' to restart";
			Time.timeScale = 0;
		}


		Slider slider = this.gameObject.GetComponent<Slider> ();
		if (slider.value >= slider.maxValue) {
			Time.timeScale = 0;
			gameOverText.gameObject.SetActive (true);
			gameOverText.text = "Game Over\nScore: " + CameraController.SCORE + "\nPress 'R' to restart";
		}


		if (PlayerController.MODE == 0) {
			slider.value += risingSpeed * Time.deltaTime;
		} else {
			slider.value -= fallingSpeed * Time.deltaTime;
		}
	}
}
