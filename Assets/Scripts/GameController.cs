using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	private GameObject player;

	// pelaajan nopeus
	public float playerSpeed = 0.05f;

	void Start () {
		player = GameObject.Find ("testipelaaja"); // temporary shits
	}

	void Update () {
		
		// player movement
		if (Input.GetKey("up")) {
			Debug.Log ("Move up");
			player.transform.Translate (0, playerSpeed, 0);
			Debug.Log (playerSpeed);
		} else if (Input.GetKey("down")) {
			Debug.Log ("Move down");
			player.transform.Translate (0, -playerSpeed, 0);
		} else if (Input.GetKey("left")) {
			Debug.Log ("Move Left");
			player.transform.Translate (-playerSpeed, 0, 0);
		} else if (Input.GetKey("right")) {
			Debug.Log ("Move right");
			player.transform.Translate (playerSpeed, 0, 0);
		}
	}

}
