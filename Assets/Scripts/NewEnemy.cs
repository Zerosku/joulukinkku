using UnityEngine;
using System.Collections;

public class NewEnemy : MonoBehaviour {

    // functions as the basic script for all the enemies in the forest level

    Player player;
    Rigidbody2D enemyrb;

    // triggering distance to the "chase player"
    int dist = 3;
    public float enemySpeed;


    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<Player>();
        enemyrb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // we had lots of different versions of the scripts that makes the enemy follow you
        // the original following script is now used for the final boss

        // it couldn't be used on the forest level because only one enemy worked with the old one

        if (player.transform.position.x < transform.position.x && (player.transform.position.x + dist) > transform.position.x)
        {
            enemyrb.velocity = new Vector2(-enemySpeed, enemyrb.velocity.y);
        }
        else if (player.transform.position.x > transform.position.x && (player.transform.position.x - dist) < transform.position.x)
        {
            enemyrb.velocity = new Vector2(enemySpeed, enemyrb.velocity.y);
        }
        else
        {
            enemyrb.velocity = new Vector2(0, enemyrb.velocity.y);
        }

        if (player.transform.position.y < transform.position.y && (player.transform.position.y + dist) > transform.position.y)
        {
            enemyrb.velocity = new Vector2(enemyrb.velocity.x, -enemySpeed);
        }
        else if (player.transform.position.y > transform.position.y && (player.transform.position.y - dist) < transform.position.y)
        {
            enemyrb.velocity = new Vector2(enemyrb.velocity.x, enemySpeed);
        }
        else
        {
            enemyrb.velocity = new Vector2(enemyrb.velocity.x, 0);
        }

    }
}
