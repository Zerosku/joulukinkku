using UnityEngine;
using System.Collections;

public class Enemy : Player {

	private static GameObject enemy;


	// Use this for initialization
	void Start () {
		enemy = GameObject.Find ("Enemy");
	}
	
	// Update is called once per frame
	void Update () {
		//EnemyTrigger.EnemyAggro ();
	}
		
}
