using UnityEngine;
using System.Collections;

public class EnemyTrigger : Enemy {

	public static GameObject EnemyCollider;

	private static bool touching = false;

	public Transform PlayerTransform;

	// enemy
	private static GameObject enemy;

	public static Vector2 paska;

	private static float enemyX;

	private static float enemyY;


	//player
	public static GameObject pelaaja;

	private static Vector2 pelaajaVector;

	private static float pelaajaX;

	private static float pelaajaY;

	//player - enemy
	private static float goX;

	private static float goY;

	// vihollisen nopeus
	public static float enemySpeed = 0.02f;

	void Start () {
		enemy = GameObject.Find ("Enemy");

		pelaaja = GameObject.Find ("Player");

		EnemyCollider = GameObject.Find ("EnemyTrigger");
	}
	
	// Update is called once per frame
	void Update () {
		
		//pelaajan x ja y
		pelaajaX = pelaaja.transform.position.x;
		pelaajaY = pelaaja.transform.position.y;

		// vihollisen x j y
		enemyX = enemy.transform.position.x;
		enemyY = enemy.transform.position.y;

		// pelaja - vihollinen = SUCCESS!
		goX = pelaajaX - enemyX;
		goY = pelaajaY - enemyY;

		// Debug.Log (paska);
		//Debug.Log(pelaaja.transform.position.x);
		Vector2 paska = enemy.transform.position;
		Vector2 pelaajaVector = pelaaja.transform.position;
	}
		
	// enemysettii
	public static void EnemyWalk (){
		//transform.LookAt (lookAtPlayer);
		pahiskeho.velocity = new Vector2 (goX , goY);
	}

	public static void EnemyAggro (){

		if (touching) {
			// Debug.Log ("enemy triggered");
			EnemyWalk ();
		} else {
			Enemy.pahiskeho.velocity = new Vector2(0, 0);
		}
	}

	// kun pelaaja osuu vihollisen enemytrigger- alueelle
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			touching = true;
		}
	}

	// hieman turha, yläolevan vastakohta
	void OnTriggerExit2D(Collider2D other) {
		if (other.tag != "Player") {
			touching = false;
		}
	}
}
