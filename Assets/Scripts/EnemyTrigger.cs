using UnityEngine;
using System.Collections;

public class EnemyTrigger : Enemy {

	private GameObject EnemyCollider;
	private static bool touching = false;

	private static GameObject enemy;

	// vihollisen nopeus
	public static float enemySpeed = 0.02f;

	// vihun vector2
	private static Vector2 enemyVector = enemy.transform.position;

	// mitä kohti lähdetään EnemyAggro () : ssa
	public static Vector2 playerMan = Player.player.transform.position;

	private static Transform transform;

	// Use this for initialization
	void Start () {
		enemy = GameObject.Find ("Enemy");
		EnemyCollider = GameObject.Find ("EnemyTrigger");
	}
	
	// Update is called once per frame
	void Update () {
		EnemyAggro ();
	}
		
	// enemysettii

	public static void EnemyAggro (){
		if (touching){
			Debug.Log ("enemy triggered");
			//transform.position = Vector2.MoveTowards(enemyVector, playerMan, enemySpeed * Time.deltaTime);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			touching = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag != "Player") {
			touching = false;
		}
	}
}
