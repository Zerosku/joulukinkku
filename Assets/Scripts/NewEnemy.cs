using UnityEngine;
using System.Collections;

public class NewEnemy : MonoBehaviour {

    Player player;
    Rigidbody2D enemyrb;
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
