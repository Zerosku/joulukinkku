using UnityEngine;
using System.Collections;

public class Player : GameController {

	private GameObject player;

	// pelaajan nopeus
	public float playerSpeed = 0.03f;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("testipelaaja");
	}

	// Update is called once per frame
	void Update () {
		Movement (playerSpeed);
	}
	// player movements
	public void Movement (float playerSpeed){
		if (Input.GetKey("up")) {
			Debug.Log ("Move up");
			player.transform.Translate (0, playerSpeed, 0);
		}
		else if (Input.GetKey("down")) {
			Debug.Log ("Move down");
			player.transform.Translate (0, -playerSpeed, 0);
		}
		else if (Input.GetKey("left")) {
			Debug.Log ("Move left");
			player.transform.Translate (-playerSpeed, 0, 0);
		}
		else if (Input.GetKey("right")) {
			Debug.Log ("Move right");
			player.transform.Translate (playerSpeed, 0, 0);
		}
	}
		
}
