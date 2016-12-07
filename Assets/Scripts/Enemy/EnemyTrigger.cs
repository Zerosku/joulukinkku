using UnityEngine;
using System.Collections;

public class EnemyTrigger : Enemy
{

    private GameObject EnemyCollider;

    private static bool touching = false;

    // enemy
    private static Transform enemy;

    private static Vector2 enemyVector;

    private  float enemyX;

    private  float enemyY;


    //player
    private  GameObject pelaaja;

    private  Vector2 pelaajaVector;

    private  float pelaajaX;

    private  float pelaajaY;

    //player - enemy
    public static float goX;

    public static float goY;

    // vihollisen nopeus
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


        //pelaajan x ja y
        pelaajaX = pelaaja.transform.position.x;
        pelaajaY = pelaaja.transform.position.y;

        // vihollisen x j y
        enemyX = enemy.transform.position.x;
        enemyY = enemy.transform.position.y;

        // pelaja - vihollinen = SUCCESS!
        goX = pelaajaX - enemyX;
        goY = pelaajaY - enemyY;

        // Debug.Log (enemyVector);
        //Debug.Log(pelaaja.transform.position.x);
        Vector2 enemyVector = enemy.transform.position;
        Vector2 pelaajaVector = pelaaja.transform.position;
    }

    // enemysettii
    public static void EnemyWalk()
    {
        //transform.LookAt (lookAtPlayer);
        pahiskeho.velocity = new Vector2(goX, goY);
    }

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

    // kun pelaaja osuu vihollisen enemytrigger- alueelle
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            touching = true;
        }
    }

    // hieman turha, yläolevan vastakohta
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag != "Player")
        {
            touching = false;
        }
    }

}
	

