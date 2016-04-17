using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		this.playerController = this.player.GetComponent<PlayerController> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.position = this.playerController.activeGameObject.transform.position + new Vector3(0, 0,-1);
	}
}
