using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		//Player.MovePlayer (playerSpeed);
	}

	void OnCollisionEnter2D (Collision2D col){
		transform.Translate (0, 1.0f, 0); // puskee pelaajan johonkin osuessaan
	}
		
}
