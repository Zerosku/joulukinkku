using UnityEngine;
using System.Collections;

public class EnemyTrigger : Enemy
{

	// this is the script for when enemy detects a player, he/she starts walking towards the piggy

    private GameObject EnemyCollider;

    private static bool touching = false;

    // enemys things
    private static Transform enemy;

    private static Vector2 enemyVector;

    private  float enemyX;

    private  float enemyY;


    //players things
    private  GameObject pelaaja;

    private  Vector2 pelaajaVector;

    private  float pelaajaX;

    private  float pelaajaY;

    //player position - enemy position
    public static float goX;

    public static float goY;

    // enemy speed
    private  float enemySpeed = 1f;

    void Start()
    {
        // enemy = GameObject.Find("Butcher");
        enemy = GetComponentInParent<Transform>();
        Debug.Log(enemy);
        pelaaja = GameObject.Find("Player");

        EnemyCollider = enemy.GetChild(0).gameObject;

        
    }

    // Update is called once per frame
    void Update()
    { 


        //players x & y position
        pelaajaX = pelaaja.transform.position.x;
        pelaajaY = pelaaja.transform.position.y;

        // enemys x & y position
        enemyX = enemy.transform.position.x;
        enemyY = enemy.transform.position.y;

        // player pos - enemy pos = SUCCESS! wanted direction
        goX = pelaajaX - enemyX;
        goY = pelaajaY - enemyY;

        // Debug.Log (enemyVector);
        //Debug.Log(pelaaja.transform.position.x);
        Vector2 enemyVector = enemy.transform.position;
        Vector2 pelaajaVector = pelaaja.transform.position;
    }

    // enemywalk starts traversing towards the player
    public static void EnemyWalk()
    {
        //transform.LookAt (lookAtPlayer);
        pahiskeho.velocity = new Vector2(goX, goY);
    }

	// enemyaggro detects if player is close enough (in range) for the enemy to start going towards to
    public static void EnemyAggro()
    {

        if (touching)
        {
            // Debug.Log ("enemy triggered");
            EnemyWalk();
        }
        else
        {
            Enemy.pahiskeho.velocity = new Vector2(0, 0);
        }
    }

    // when player touches the enemys enemytrigger- area
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            touching = true;
        }
    }

    // opposite of ontriggerstay2d, whe player is NOT touching the area
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Player")
        {
            touching = false;
        }
    }

}
	

