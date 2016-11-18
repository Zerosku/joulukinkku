using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private static GameObject enemy;

	public static Rigidbody2D pahiskeho;

	// Use this for initialization
	void Start () {
		enemy = GameObject.Find ("Enemy");
		pahiskeho = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.identity;

		EnemyTrigger.EnemyAggro ();
	}
		
}
